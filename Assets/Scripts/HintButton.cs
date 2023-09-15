using Agava.YandexGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HintButton : MonoBehaviour
{
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
        //_audioMuteHandler.UnmuteAudio();
        //_adIsPlaying = false;
    }

    private void OnPlayed()
    {
        //_audioMuteHandler.MuteAudio();
        _adIsPlaying = true;
    }
}
