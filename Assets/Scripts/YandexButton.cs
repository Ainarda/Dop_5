using KimicuUtility;
using KiYandexSDK;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class YandexButton : MonoBehaviour
{
    [SerializeField] private ProductType _productType;
    [SerializeField] private Hint _hint;
    

    private Button _buttonAd;

    private void Awake()
    {
        if((bool)YandexData.Load(AdvertSDK.AdvertOffKey,false)&& _productType== ProductType.RemoveAds)
        {
            gameObject.SetActive(false);
        }    

        _buttonAd = GetComponent<Button>();
        _buttonAd.AddListener(Purchase);
    }

    private void Purchase()
    {
        string id ="";

        switch (_productType)
        {
            case ProductType.RemoveAds:
                id= ProductId.IdProductNoAds;
                break;

            case ProductType.ShowHint:
                id = ProductId.IdProductHint;
                break;
        }
        Billing.PurchaseProduct(id, onSuccessPurchase: (response) =>
        {
            switch (_productType)
            {
                case ProductType.RemoveAds:
                    AdvertSDK.AdvertOff();
                    gameObject.SetActive(false);
                    YandexData.Save(AdvertSDK.AdvertOffKey,true);
                    
                    break;

                case ProductType.ShowHint:
                    _hint.StartHint();
                    break;
            } 
        }, onSuccessConsume: null);
    }



}
