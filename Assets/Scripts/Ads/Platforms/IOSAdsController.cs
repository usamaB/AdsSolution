using UnityEngine;
using System.Collections;

namespace MS.Ads
{
    public class IOSAdsController : IAds
    {
        private FyberController _fyberController;        
        public IOSAdsController()
        {
            _fyberController = new FyberController();
        }
        
        public void ShowVideoAd()
        {
            _fyberController.ShowVideoAd();
        }
        
        public void PreLoadVideoAd()
        {
            _fyberController.RequestVideoAd();
        }
        
        public bool IsVideoAdAvailable()
        {
            return _fyberController.IsVideoAdAvailable;
        }
    }
}