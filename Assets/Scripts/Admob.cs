using UnityEngine;
using System;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class Admob : MonoBehaviour
{
    private BannerView adBanner;
    private InterstitialAd interstitial;
    private string idBanner;
    private string adUnitId = "ca-app-pub-2156903006472432/8362202914";

    void Start()
    {        
        idBanner = "ca-app-pub-2156903006472432/6122998486";
      
        MobileAds.Initialize(initStatus => { });
       
        RequestBannerAd();
        RequestInterstitial();
    }

    #region Banner Methods
    public void RequestBannerAd()
    {
        adBanner = new BannerView(idBanner, AdSize.Banner, AdPosition.Top);
        AdRequest request = AdRequestBuild();
        adBanner.LoadAd(request);
    }

    public void DestroyBannerAd()
    {
        if (adBanner != null)
            adBanner.Destroy();
    }
    #endregion


    #region Interstitial implementation

    private void RequestInterstitial()
    {
        this.interstitial = new InterstitialAd(adUnitId);
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Ad failed to load");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        Debug.Log("HandleOnAdClosed");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AdCall()
    {
        if (this.interstitial.IsLoaded())
        {
             this.interstitial.Show();
        }
        else
        {
            Debug.Log("Ad is called");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    #endregion

    AdRequest AdRequestBuild()
    {
        return new AdRequest.Builder().Build();
    }
}
