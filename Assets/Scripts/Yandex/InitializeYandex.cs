using KiYandexSDK;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerPrefs = UnityEngine.PlayerPrefs;

public class InitializeYandex : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private int _currentLevel = 1;

    private void Start()
    {
        OnInitialize();
    }
    public void OnInitialize()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            _currentLevel = (int)YandexData.Load("CurrentLevel", 1);  
        }
        DontDestroyOnLoad(_audio);
        SceneManager.LoadScene(_currentLevel);
    }
}