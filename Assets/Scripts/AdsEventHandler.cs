using UnityEngine;
using MS.Ads;

namespace Test.Main
{
    public class AdsEventHandler : MonoBehaviour 
    {
        public void PreLoadAds()
        {
            FindObjectOfType<AdManager>().PreLoadVideoAd();
        }
        
        public void ShowAds()
        {
            FindObjectOfType<AdManager>().ShowVideoAd();
        }
    }
}