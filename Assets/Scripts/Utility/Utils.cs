// #define AMAZON
using UnityEngine;

namespace MS.Utility
{
    public static class Utils
    {
        public static bool IsAmazonPlatform = false; 
        #if (AMAZON)        
         	   IsAmazonPlatform = true;                
        #endif
        public static bool IsNetWorkAvailable()
        {
            return (Application.internetReachability != NetworkReachability.NotReachable);
        }
    }
}