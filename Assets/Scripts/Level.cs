using System.Collections;
using System.Collections.Generic;
using KiYandexSDK;
using Lean.Localization;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadNextLevel()
    {
        AdvertSDK.InterstitialAd(onClose: _ => 
            GoOverLevel(),onError: _=> GoOverLevel() , onOffline: GoOverLevel);
    }

    private void GoOverLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 25;
        }
        YandexData.Save("CurrentLevel", nextSceneIndex);
        SceneManager.LoadScene(nextSceneIndex);
    }
}