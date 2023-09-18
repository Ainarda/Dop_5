using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Image buttonImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private AudioSource audioSource;

    AudioSource[] musicPlayers;

    private bool isSoundOn = true;

    private void Start()
    {
        musicPlayers = FindObjectsOfType<AudioSource>();

        if (musicPlayers.Length == 1)
        {
            DontDestroyOnLoad(musicPlayers[0]);
        }
        else
        {
            Destroy(musicPlayers[1]);
        }

        audioSource = FindObjectOfType<AudioSource>();

        SetButtonImage();
        LoadVolumeAudio();
    }

    public void ToggleSound()
    {
        if (isSoundOn)
        {
            OffSound();
        }
        else
        {
            OnSound();
        }
        
    }

    private void OnSound()
    {
        isSoundOn =true;
        buttonImage.sprite = soundOnSprite;
        AudioListener.volume = 0.2f;
        //audioSource.volume = 1f;
        SaveVolumeAudio();
    }
    private void OffSound()
    {
        isSoundOn = false;
        buttonImage.sprite = soundOffSprite;
        audioSource.volume = 0f;
        SaveVolumeAudio();
    }
    private void SaveVolumeAudio()
    {
        PlayerPrefs.SetFloat("CurrentVolume", audioSource.volume);
    }

    private void LoadVolumeAudio()
    {
        if (PlayerPrefs.HasKey("CurrentVolume"))
        {
            
            print(PlayerPrefs.GetFloat("CurrentVolume"));
            if (PlayerPrefs.GetFloat("CurrentVolume")==1)
            {
                isSoundOn=true;
                OnSound();
            }
            else
            {
                isSoundOn = false;
                OffSound();
            }
        }
        else
        {
            
            OnSound();
        }
    }

    private void SetButtonImage()
    {
        buttonImage.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
    }
}
