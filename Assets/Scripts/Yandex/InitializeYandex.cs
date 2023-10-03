using KiYandexSDK;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeYandex : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private YandexSDKInitialize _yandexSDKInitialize;


    private int _currentLevel = 1;

    

    public void OnInitialize()
    {
        Player.Initialize();

        _currentLevel = (int)YandexData.Load("CurrentLevel", 1);
        DontDestroyOnLoad(_audio);

        if (Billing.PurchasedProducts == null) 
        {
            SceneManager.LoadScene(_currentLevel);
            return;
        }

        foreach (var product in Billing.PurchasedProducts)
        {
            if (product.productID == ProductId.IdProductNoAds)
            {
                AdvertSDK.AdvertOff();
            }

            if (product.productID == ProductId.IdProductHint)
            {
                Player.IsAvailbleHint = true;
                
            }
            Billing.ConsumeProduct(product.purchaseToken);

        }
        SceneManager.LoadScene(_currentLevel);
    }
}
