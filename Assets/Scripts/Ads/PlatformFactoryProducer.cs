using UnityEngine;
using System.Collections.Generic;
using MS.Utility;

namespace MS.Ads
{
    public class PlatformFactoryProducer
    {
        private readonly Dictionary<RuntimePlatform, IAds> _platformDict = new Dictionary<RuntimePlatform, IAds>()
        {
            {RuntimePlatform.Android, new AndroidAdsController()},
            {RuntimePlatform.Android, new WindowsAdsController()},
            {RuntimePlatform.IPhonePlayer, new IOSAdsController()}
        };
        
        public IAds CreateFactory(RuntimePlatform platform)
        {
            if (!(platform == RuntimePlatform.Android && Utils.IsAmazonPlatform))
                return _platformDict[platform];
            else
                return new AmazonAdsController();
        }
    }
}