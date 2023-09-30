using System.Collections;
using System.Collections.Generic;
using KiYandexSDK;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadNextLevel()
    {
        Debug.Log("Переход на уровень");
        AdvertSDK.InterstitialAd(onClose: _ => 
            GoOverLevel(),onError: _=> GoOverLevel() , onOffline: GoOverLevel);
    }

    private void GoOverLevel()
    {
        Debug.Log("Переход на уровень 1");
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Переход на уровень 2");
            YandexData.Save("CurrentLevel", nextSceneIndex);
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}