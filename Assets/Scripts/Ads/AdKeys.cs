﻿#define UNITY_AMAZON
namespace MS.Ads
{
    public static class AdKeys 
    {        
        #if UNITY_ANDROID
        public static string FyberAppId = "40473";
        public static string FyberUserId = "";
        public static string FyberSecurityToken = "25c96bd97e2c730375c61a16e324a86a";
        #elif UNITY_IOS        
        public static string FyberAppId = "40473";
        public static string FyberUserId = "";
        public static string FyberSecurityToken = "25c96bd97e2c730375c61a16e324a86a";
        #elif UNITY_WINRT_10_0 || UNITY_WINRT_8_1
        #elif UNITY_AMAZON
        #endif
    }
}