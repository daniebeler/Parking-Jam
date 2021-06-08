using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

public class AdManger : MonoBehaviour
{
    private BannerView bannerView;
    private string adUnitId = "";

    void Start()
    {
        PlayerPrefs.SetInt("loadtestad", 0);        // 1 = Test Ad  ; 0 = Produktion Ad

        if (PlayerPrefs.GetInt("loadtestad", 0) == 1)
        {
#if UNITY_ANDROID
            adUnitId = "ca-app-pub-3940256099942544/6300978111";      // Test Banner: Android
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/2934735716";      // Test Banner: iOS
#else
            adUnitId = "unexpected_platform";
#endif
        }
        else
        {
#if UNITY_ANDROID
            adUnitId = "ca-app-pub-9891259559985223/9352754685";      // Produktion Banner: Android
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-9891259559985223/9750949121";      // Produktion Banner: iOS
#else
            adUnitId = "unexpected_platform";
#endif
        }

        MobileAds.Initialize(initStatus =>
        {
            Debug.Log("intitStatus: " + initStatus.ToString());
            RequestBanner();
        });

        //MobileAds.Initialize("ca-app-pub-9891259559985223~1517235887");
        //MobileAds.Initialize(Action<InitializationStatus>comple)

    }

    private void RequestBanner()
    {
        // Create a banner.
        bannerView = new BannerView(adUnitId, AdSize.GetPortraitAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth), AdPosition.Bottom);

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
