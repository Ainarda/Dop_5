using Agava.YandexGames;
using KiYandexSDK;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RewardButton : MonoBehaviour, IPointerUpHandler
{
    public UnityEvent OnClick;
    
    public void OnPointerUp(PointerEventData eventData)
    {
        OnClick?.Invoke();
        Billing.PurchaseProduct("NoAds", OnSuccessPurchases);
    }

    private static void OnSuccessPurchases(PurchaseProductResponse response)
    {
        AdvertSDK.AdvertOff();
    }
}