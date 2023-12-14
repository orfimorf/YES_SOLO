using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class CheackConnectYG : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += CheakSDK;

    private void OnDisable() => YandexGame.GetDataEvent -= CheakSDK;
    
    
    private TextMeshProUGUI scoreBest;

    void Start()
    {
        Debug.Log(YandexGame.SDKEnabled);
        if (YandexGame.SDKEnabled == true)
        {
            CheakSDK();
        }
    }

    // Update is called once per frame
    public void CheakSDK()
    {
        if (YandexGame.auth == true)
        {
            Debug.Log("200");
        }
        else
        {
            Debug.Log("401");
            YandexGame.AuthDialog();
        }
        GameObject scoreGO = GameObject.Find("BestScore");
        scoreBest = scoreGO.GetComponent<TextMeshProUGUI>();
        scoreBest.text = "Best Score: " + YandexGame.savesData.beastScore.ToString();

    }
}
