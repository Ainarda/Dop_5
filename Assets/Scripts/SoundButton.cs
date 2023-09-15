using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Image buttonImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public AudioSource audioSource;

    private bool isSoundOn = true;

    private void Start()
    {
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
        audioSource.volume = 1f;
    }
    private void OffSound()
    {
        isSoundOn = false;
        buttonImage.sprite = soundOffSprite;
        audioSource.volume = 0f;
    }
    private void SaveVolumeAudio()
    {
        PlayerPrefs.SetFloat("CurrentVolume", audioSource.volume);
    }

    private void LoadVolumeAudio()
    {
        if (PlayerPrefs.HasKey("CurrentVolume"))
        {
            if (PlayerPrefs.GetFloat("CurrentVolume")==1)
            {
                OnSound();
            }
            else
            {
                OffSound();
            }
        }
    }

    private void SetButtonImage()
    {
        buttonImage.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
    }
}
