using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    
    Action onRewardedAdSuccess;
    
    private void Start()
    {
        Advertisement.Initialize("4774458");
        Advertisement.AddListener(this);
    }

    public void PlayRewardedAd(Action onSuccess)
    {
        onRewardedAdSuccess = onSuccess;
        
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            Debug.Log("Rewarded ad is not ready!");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("ADS ARE READY!");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ERROR: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("VIDEO STARTED");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            onRewardedAdSuccess.Invoke();
            
        }
        
        
    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }


}
