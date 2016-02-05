using UnityEngine;

namespace MS.Ads.Utility
{
    public static class Utils
    {
        public static bool IsNetWorkAvailable()
        {
            return (Application.internetReachability != NetworkReachability.NotReachable);
        }
    }
}