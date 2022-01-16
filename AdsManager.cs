using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : Singleton<AdsManager>
{  

    [Header("Ads ID's")]
    [SerializeField] private string _bannerAdID;
    [SerializeField] private string _interstitialVideoAdID;
    private BannerView _bannerAd; 
    private InterstitialAd _interstitialAd;


    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        _bannerAd = new BannerView(_bannerAdID, AdSize.SmartBanner, AdPosition.Bottom);
        _interstitialAd = new InterstitialAd(_interstitialVideoAdID);
    }

    public void RequestInterstitialAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        _interstitialAd.LoadAd(request);

        if (_interstitialAd.IsLoaded())
        {
            _interstitialAd.Show();
        }
    }

    public void RequestBannerAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        _bannerAd.LoadAd(request);
    }

    public void HideBannerAd()
    {
        _bannerAd.Hide();
    }

    public void DestroyBannerAd()
    {
        _bannerAd.Destroy();
    }
}


