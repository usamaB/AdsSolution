// # define UNITY_AMAZON
namespace MS.Ads
{
    public static class AdKeys 
    {
        public const string FyberAppId = "40473";
        public const string FyberUserId = "";
        public const string FyberSecurityToken = "25c96bd97e2c730375c61a16e324a86a";
        
        #if UNITY_ANDROID
        #elif UNITY_IOS        
        #elif UNITY_WINRT_10_0 || UNITY_WINRT_8_1
        #elif UNITY_AMAZON
        #endif
    }
}