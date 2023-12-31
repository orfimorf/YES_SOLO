using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using TMPro;
using UnityEngine.SocialPlatforms;

public class DragonPicker : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += GetLoadSave;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoadSave;

    public GameObject energyShieldPrefab;

    public int numEnergyShield = 3;

    public float energyShieldBottomY = -6f;

    public float energyShieldRadius = 1.5f;

    public List<GameObject> shieldList;

    public TextMeshProUGUI scoreGT, playerName;

    void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoadSave();
        }
        shieldList = new List<GameObject>();



        for (int i = 1; i <= numEnergyShield; i++)
        {
            GameObject tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            tShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShieldGo.transform.localScale = new Vector3(1 * i, 1 * i, 1 * i);
            shieldList.Add(tShieldGo);  
        }

       
        GameObject plName = GameObject.Find("PLayerName");
        playerName = plName.GetComponent<TextMeshProUGUI>();
        playerName.text = YandexGame.playerName;

    }

    void Update()
    {
        
    }

    public void DragonEggDestroyed()
    {
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("Dragon Egg");
        foreach (GameObject tGO in tDragonEggArray)
        {
            Destroy(tGO);
        }
        int shieldIndex = shieldList.Count - 1; 
        GameObject tShieldGo = shieldList[shieldIndex];
        shieldList.RemoveAt(shieldIndex);
        Destroy(tShieldGo);

        if (shieldList.Count == 0)
        {
            GameObject scoreGO = GameObject.Find("Score");
            scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
            UserSave(int.Parse(scoreGT.text));
            //string[] achivList;
            //achivList = YandexGame.savesData.achivse;
            //achivList[0] = "������ ����!";
            //UserSave(achivList);
            string[] achivList;
            achivList = new string[10];
            achivList[0] = "������ ����";
            UserSave(achivList);
            YandexGame.NewLeaderboardScores("TOPPlayerScore",int.Parse(scoreGT.text));
            SceneManager.LoadScene("_0Scene");
            GetLoadSave();
        }
    }
    public void GetLoadSave() 
    {
        Debug.Log( YandexGame.savesData.score);


    }

    public void UserSave(int curScore)
    {
        YandexGame.savesData.score = curScore;
        if (curScore >  YandexGame.savesData.beastScore) YandexGame.savesData.beastScore = curScore;   
        YandexGame.SaveProgress();
    }

    public void UserSave(string[] achivList)
    {
        YandexGame.savesData.achivse = achivList;
        YandexGame.SaveProgress();
    }
}
