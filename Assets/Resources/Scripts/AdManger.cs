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
        bool productionAds = false;

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

        Debug.Log("Showed intersititial");
    }

    public void RequestBanner()
    {
        // Create a banner.
        bannerView = new BannerView(adUnitIdBanner, AdSize.GetPortraitAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth), AdPosition.Bottom);

        // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        bannerView.OnAdOpening += HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        bannerView.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
        bannerView.Show();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
}
