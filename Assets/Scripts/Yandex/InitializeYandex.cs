using KiYandexSDK;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerPrefs = UnityEngine.PlayerPrefs;

public class InitializeYandex : MonoBehaviour
{
    public void OnInitialize()
    {
        int currentLevel = (int)YandexData.Load("CurrentLevel", 1);
        SceneManager.LoadScene(currentLevel);
    }
}