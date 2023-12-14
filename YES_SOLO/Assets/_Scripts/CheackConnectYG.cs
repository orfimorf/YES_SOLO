using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class CheackConnectYG : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += CheakSDK;

    private void OnDisable() => YandexGame.GetDataEvent -= CheakSDK;

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
    }
}
