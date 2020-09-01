using System;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.Events;
using GoogleMobileAds.Common;

public class Admob// : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitialAd;    // full screen ad

    private bool isTestMode = false;

    private string androidAppId = "ca-app-pub-5980043842552496~3697586795";

    public UnityEvent OnAdLoadedEvent;
    public UnityEvent OnAdFailedToLoadEvent;
    public UnityEvent OnAdOpeningEvent;
    public UnityEvent OnAdFailedToShowEvent;
    public UnityEvent OnUserEarnedRewardEvent;
    public UnityEvent OnAdClosedEvent;
    public UnityEvent OnAdLeavingApplicationEvent;

    public void Init()
    {
        //this.RequestBannerAd();
        this.RequestInterstitial();
    }

    public void FullScreenAdsShow()
    {
        if (this.interstitialAd.IsLoaded())
        {
            this.interstitialAd.Show();
        }
    }

    public void BannerAdsShow()
    {
        if (this.bannerView == null)
        {
            return;
        }

        this.bannerView.Show();
    }

    public void RequestInterstitial()
    {
        string adUnitId;

#if UNITY_ANDROID        
        if (this.isTestMode)
        {
            adUnitId = "ca-app-pub-3940256099942544/1033173712";
        }
        else
        {
            adUnitId = "ca-app-pub-5980043842552496/5749035061";
        }
#elif UNITY_IPHONE
        adUnitId = "ca-app-pub-5980043842552496/5749035061";
#else
        adUnitId = "unexpected_platform";
#endif

        // Clean up interstitial before using it
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }

        interstitialAd = new InterstitialAd(adUnitId);

        // Add Event Handlers
        interstitialAd.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        interstitialAd.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        interstitialAd.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        interstitialAd.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();
        interstitialAd.OnAdLeavingApplication += (sender, args) => OnAdLeavingApplicationEvent.Invoke();

        // Load an interstitial ad
        interstitialAd.LoadAd(CreateAdRequest());
    }

    private void RequestBannerAd()
    {
        string adUnitId;

#if UNITY_ANDROID
        if (this.isTestMode)
        {
            adUnitId = "ca-app-pub-3940256099942544/6300978111";
        }
        else
        {
            adUnitId = "ca-app-pub-5980043842552496/7727443099";
        }
#else
        adUnitId = "unDefind";
#endif

        // Clean up banner before reusing
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        // Create a 320x50 banner at top of the screen
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);

        // Add Event Handlers
        bannerView.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        bannerView.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        bannerView.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        bannerView.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();
        bannerView.OnAdLeavingApplication += (sender, args) => OnAdLeavingApplicationEvent.Invoke();

        // Load a banner ad
        bannerView.LoadAd(CreateAdRequest());
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
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

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
 /*           .AddTestDevice(AdRequest.TestDeviceSimulator)
            .AddTestDevice("D5FF1666F73EBCA126D4FF5569009B8C")
            .AddKeyword("unity-admob-sample")
            .TagForChildDirectedTreatment(false)
            .AddExtra("color_bg", "9B30FF")
*/            .Build();
    }
}
