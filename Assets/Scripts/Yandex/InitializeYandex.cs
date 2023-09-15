using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.SceneManagement;
using PlayerPrefs = UnityEngine.PlayerPrefs;

public class InitializeYandex : MonoBehaviour
{
#if UNITY_EDITOR

#endif

#if UNITY_WEBGL && !UNITY_EDITOR
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize(OnInitialize);
    }
#endif

    private void OnInitialize()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            SceneManager.LoadScene(currentLevel);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
        
    }
}
