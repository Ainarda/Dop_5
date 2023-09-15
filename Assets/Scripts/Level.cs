using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        GameObject audio =GameObject.FindObjectOfType(typeof(AudioSource)) as GameObject;

        if (audio!=null)
        {
            print(gameObject.name);
            Destroy(gameObject);
        }
        else
        {
            print(gameObject.name+"1");
            DontDestroyOnLoad(audioSource.gameObject);
        }
        

        //audioSource.Play();
    }
  
    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt("CurrentLevel", nextSceneIndex);
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
