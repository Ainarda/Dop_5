using UnityEngine;
using KiYandexSDK;
using UnityEngine.Events;

public class AdButton : MonoBehaviour
{
    public UnityAction RewardClosed;

    public void OnShowVideoButtonClick()
    {
        AdvertSDK.RewardAd(onClose: () => RewardClosed?.Invoke());
    }

    public void PlayAd()
    {
        AdvertSDK.InterstitialAd();
    }
}