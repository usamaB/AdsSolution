#define UNITY_AMAZON
using UnityEngine;

namespace MS.Utility
{
    public static class Utils
    {
        public static bool IsAmazonPlatform
        {
            get
            {
                #if UNITY_AMAZON
                return true;
                #endif
                return false;
            }
        }                                         	                           
        public static bool IsNetWorkAvailable()
        {
            return (Application.internetReachability != NetworkReachability.NotReachable);
        }
    }
}