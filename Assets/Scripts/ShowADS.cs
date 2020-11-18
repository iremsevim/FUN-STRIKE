using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
public class ShowADS : MonoBehaviour
{
    public static ShowADS instance;
    public InterstitialAd interstıtal;
   

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {

        MobileAds.Initialize((reklamver ) => { });
        

    }

    public AdRequest RequestAD()
    {
        AdRequest request = new AdRequest.Builder().Build();
        return request;
    }
    public void AddAD()
    {
        string UnıtID = "ca-app-pub-3940256099942544/1033173712";
        interstıtal = new InterstitialAd(UnıtID);
        interstıtal.OnAdClosed += CatcHGameOver;
        interstıtal.LoadAd(RequestAD());
         
    }
    public void ShowAd()
    {

        if (!interstıtal.IsLoaded()) return; 
        interstıtal.Show();
    }
    public void CatcHGameOver(object sender,System.EventArgs e)
    {
        GameManager.instance.Restart();   
    }
}
