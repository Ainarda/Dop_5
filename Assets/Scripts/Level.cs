using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Agava.YandexGames;
using KiYandexSDK;
using Lean.Localization;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private NumberLevel _numberLevel;
    public static bool IsReadyInvoke;

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (!IsReadyInvoke)
        {
            YandexGamesSdk.GameReady();
            IsReadyInvoke = true;
        }
#endif

    }
    public void LoadNextLevel()
    {
        AdvertSDK.InterstitialAd(onClose: _ => 
            GoOverLevel(),onError: _=> GoOverLevel() , onOffline: GoOverLevel);
    }

    private void GoOverLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        _numberLevel.ChangeLevel();

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 25;
        }
        YandexData.Save("CurrentLevel", nextSceneIndex);
        SceneManager.LoadScene(nextSceneIndex);
    }
}