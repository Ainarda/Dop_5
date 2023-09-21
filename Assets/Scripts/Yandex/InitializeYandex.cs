using KiYandexSDK;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerPrefs = UnityEngine.PlayerPrefs;

public class InitializeYandex : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    public void OnInitialize()
    {
        int currentLevel = (int)YandexData.Load("CurrentLevel", 1);
        DontDestroyOnLoad(_audio);
        SceneManager.LoadScene(currentLevel);
    }
}