using System.Collections;
using System.Collections.Generic;
using KiYandexSDK;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;

    private AudioSource _music;

    private void Start()
    {
        LoadVolumeAudio();
    }

    public void ToggleSound()
    {

        if (AudioListener.volume == 1f)
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
        buttonImage.sprite = soundOnSprite;
        AudioListener.volume = 1f;
        SaveVolumeAudio();
    }
    private void OffSound()
    {
        buttonImage.sprite = soundOffSprite;
        AudioListener.volume = 0f;
        SaveVolumeAudio();
    }
    private void SaveVolumeAudio()
    {
        YandexData.Save("CurrentVolume",(int) AudioListener.volume);
    }

    private void LoadVolumeAudio()
    {
        if ((int)(YandexData.Load("CurrentVolume", 1))==1)
        {
            OnSound();
        }
        else
        {
            OffSound();
        }
        //else
        //{
        //    OnSound();
        //}
    }
}
