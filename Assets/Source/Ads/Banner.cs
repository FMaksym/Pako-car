using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class Banner : MonoBehaviour
{
    public BannerView _bannerView;

    public void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
        });

        RequestBanner();
    }

    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  private string _adUnitId = "unused";
#endif

    private void RequestBanner()
    {
        _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Bottom);

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        this._bannerView.LoadAd(adRequest);
    }
}
