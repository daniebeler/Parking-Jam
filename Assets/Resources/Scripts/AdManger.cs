using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManger : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private string adUnitIdBanner = "";
    private string adUnitIdInterstitial = "";

    void Start()
    {
        bool productionAds = true;

        if (productionAds)
        {
#if UNITY_ANDROID
            adUnitIdBanner = "ca-app-pub-9891259559985223/9352754685";              // Produktion Banner: Android
            adUnitIdInterstitial = "ca-app-pub-9891259559985223/8952244136";        // Produktion Interstitial: Android
#elif UNITY_IPHONE
            adUnitIdBanner = "ca-app-pub-9891259559985223/9750949121";      // Produktion Banner: iOS
            adUnitIdInterstitial = "not_set";      // Produktion Interstitial: iOS
#else
            adUnitIdBanner = "unexpected_platform";
            adUnitIdInterstitial = "unexpected_platform";
#endif
        }
        else
        {
#if UNITY_ANDROID
            adUnitIdBanner = "ca-app-pub-3940256099942544/6300978111";      // Test Banner: Android
            adUnitIdInterstitial = "ca-app-pub-3940256099942544/1033173712";      // Test Interstitial: Android
#elif UNITY_IPHONE
            adUnitIdBanner = "ca-app-pub-3940256099942544/2934735716";      // Test Banner: iOS
            adUnitIdInterstitial = "not_set";      // Test Interstitial: iOS
#else
            adUnitIdBanner = "unexpected_platform";
            adUnitIdInterstitial = "unexpected_platform";
#endif
        }
    }

    public void init()
    {
        MobileAds.Initialize(initStatus =>
        {
            Debug.Log("intitStatus: " + initStatus.ToString());
        });
    }

    public void loadInterstitial()
    {
        AdRequest request = new AdRequest.Builder().Build();
        interstitial = new InterstitialAd(adUnitIdInterstitial);
        interstitial.LoadAd(request);
    }

    public void showInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void RequestBanner()
    {
        bannerView = new BannerView(adUnitIdBanner, AdSize.GetPortraitAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth), AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }

    void OnDestroy()
    {
        try
        {
            interstitial.Destroy();
        }
        catch (Exception e)
        {
            
        }
    }
}
