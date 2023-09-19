using System.Collections;
using System.Collections.Generic;
using KiYandexSDK;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    //public AudioSource audioSource;

    private void Start()
    {
        //GameObject audio = GameObject.FindObjectOfType(typeof(AudioSource)) as GameObject;

        ////if (audioSource != null)
        ////{
        ////    Destroy(audioSource.gameObject);
        ////}
        ////else
        ////{
        // /* }*/   DontDestroyOnLoad(audioSource.gameObject);
       


        //audioSource.Play();
    }

    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            YandexData.Save("CurrentLevel", nextSceneIndex);
            SceneManager.LoadScene(nextSceneIndex);
        }

    }
}
