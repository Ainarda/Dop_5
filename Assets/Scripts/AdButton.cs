using Agava.YandexGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AdButton : MonoBehaviour
{
    [SerializeField] private AudioMuteHandler _audioMuteHandler;
    private bool _adIsPlaying;

    public bool AdIsPlaying => _adIsPlaying;

    public Action OnWatchedAd;
    public void OnShowVideoButtonClick()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        VideoAd.Show(OnPlayed, OnRewarded,OnClosed);
#endif
    }

    public void OnRewarded()
    {
        OnWatchedAd?.Invoke();
    }

    private void OnClosed()
    {
        _audioMuteHandler.UnmuteAudio();
        _adIsPlaying = false;
    }

    private void OnPlayedAd()
    {
        _audioMuteHandler.MuteAudio();
        _adIsPlaying = true;
    }
    private void ShowInterstitialAd()
    {
        InterstitialAd.Show(OnPlayed, OnClosedInterstitialAd);
    }
    public void PlayAd()
    {
        ShowInterstitialAd();
    }

    private void OnPlayed()
    {
        _audioMuteHandler.MuteAudio();
        _adIsPlaying = true;
    }
    private void PlayRegularAdIf(bool value)
    {
        if (value)
        {
            ShowInterstitialAd();
        }
    }


    private void OnClosedInterstitialAd(bool value)
    {
        _audioMuteHandler.UnmuteAudio();
        _adIsPlaying = false;
    }
}
