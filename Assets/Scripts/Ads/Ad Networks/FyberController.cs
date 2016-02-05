using FyberPlugin;

namespace MS.Ads
{
    
    public class FyberController
    {
        #region Fields
        // Contains app settings for fyber.
        private Settings _settings;

        // Contains RewardedVideoAd Info.
        private Ad _rewardedVideoAd;

        private bool _isVideoAdAvailable;
        private const string k_appId = "40473";
        private const string k_userId = "";
        private const string k_securityToken = "25c96bd97e2c730375c61a16e324a86a";

        public bool IsVideoAdAvailable
        {
            get { return _isVideoAdAvailable; }
        }

        #endregion

        #region Constructors        
        public FyberController()
        {
            _settings = Fyber.With(k_appId)
            .WithUserId(k_userId)
            .WithSecurityToken(k_securityToken)
            .Start();

            // Ad availability
            FyberCallback.AdAvailable += OnAdAvailable;
            FyberCallback.AdNotAvailable += OnAdNotAvailable;
            FyberCallback.RequestFail += OnRequestFail;
            FyberCallback.AdStarted += OnAdStarted;
            FyberCallback.AdFinished += OnAdFinished;
            FyberCallback.VirtualCurrencySuccess += OnCurrencyResponse;
            FyberCallback.VirtualCurrencyError += OnCurrencyErrorResponse;
            FyberCallback.NativeError += OnNativeExceptionReceivedFromSDK;
        }

        public FyberController(string appId)
        {
            _settings = Fyber.With(appId)
            .Start();

            // Ad availability
            FyberCallback.AdAvailable += OnAdAvailable;
            FyberCallback.AdNotAvailable += OnAdNotAvailable;
            FyberCallback.RequestFail += OnRequestFail;
            FyberCallback.AdStarted += OnAdStarted;
            FyberCallback.AdFinished += OnAdFinished;
            FyberCallback.VirtualCurrencySuccess += OnCurrencyResponse;
            FyberCallback.VirtualCurrencyError += OnCurrencyErrorResponse;
            FyberCallback.NativeError += OnNativeExceptionReceivedFromSDK;
        }

        public FyberController(string appId, string userId)
        {
            _settings = Fyber.With(appId)
            .WithUserId(userId)
            .Start();

            // Ad availability
            FyberCallback.AdAvailable += OnAdAvailable;
            FyberCallback.AdNotAvailable += OnAdNotAvailable;
            FyberCallback.RequestFail += OnRequestFail;
            FyberCallback.AdStarted += OnAdStarted;
            FyberCallback.AdFinished += OnAdFinished;
            FyberCallback.VirtualCurrencySuccess += OnCurrencyResponse;
            FyberCallback.VirtualCurrencyError += OnCurrencyErrorResponse;
            FyberCallback.NativeError += OnNativeExceptionReceivedFromSDK;
        }

        public FyberController(string appId, string userId, string securityToken)
        {
            _settings = Fyber.With(appId)
            .WithUserId(userId)
            .WithSecurityToken(securityToken)
            .Start();

            // Ad availability
            FyberCallback.AdAvailable += OnAdAvailable;
            FyberCallback.AdNotAvailable += OnAdNotAvailable;
            FyberCallback.RequestFail += OnRequestFail;
            FyberCallback.AdStarted += OnAdStarted;
            FyberCallback.AdFinished += OnAdFinished;
            FyberCallback.VirtualCurrencySuccess += OnCurrencyResponse;
            FyberCallback.VirtualCurrencyError += OnCurrencyErrorResponse;
            FyberCallback.NativeError += OnNativeExceptionReceivedFromSDK;
        }
        #endregion

        #region CleanUp
        // CleanUp Here
        ~FyberController()
        {
            // Ad availability
            FyberCallback.AdAvailable -= OnAdAvailable;
            FyberCallback.AdNotAvailable -= OnAdNotAvailable;
            FyberCallback.RequestFail -= OnRequestFail;
            FyberCallback.AdStarted -= OnAdStarted;
            FyberCallback.AdFinished -= OnAdFinished;
            FyberCallback.VirtualCurrencySuccess -= OnCurrencyResponse;
            FyberCallback.VirtualCurrencyError -= OnCurrencyErrorResponse;
            FyberCallback.NativeError -= OnNativeExceptionReceivedFromSDK;
        }
        #endregion

        #region Methods

        //Requests a RewardedVideo based on parameters
        public void RequestVideoAd()
        {

            VirtualCurrencyRequester virtualCurrencyRequester = VirtualCurrencyRequester.Create()
            // optional method chaining
            // .AddParameter("key", "value")
            // .AddParameters(dictionary)
            // Overrideing currency Id
            // .ForCurrencyId(currencyId)
            // Changing the GUI notification behaviour for when the user is rewarded
            .NotifyUserOnReward(false)
            // you don't need to add a callback if you are using delegates
            //.WithCallback(vcsCallback)
            ;

            RewardedVideoRequester.Create()
            // optional method chaining
            //.AddParameter("key", "value")
            //.AddParameters(dictionary)
            //.WithPlacementId(placementId)
            // changing the GUI notification behaviour when the user finishes viewing the video
            .NotifyUserOnCompletion(false)
            // you can add a virtual currency requester to a video requester instead of requesting it separately
            .WithVirtualCurrencyRequester(virtualCurrencyRequester)
            // you don't need to add a callback if you are using delegates
            //.WithCallback(requestCallback)
            // requesting the video
            .Request();
        }

        //Shows a rewardedVideo if available.
        public void ShowVideoAd()
        {
            if (_rewardedVideoAd != null)
            {
                _rewardedVideoAd.Start();
                _rewardedVideoAd = null;
            }
        }

        #endregion

        #region EventHandlers
        //Handle Exception here
        private void OnNativeExceptionReceivedFromSDK(string message)
        {
            //handle exception
        }

        // Checks Ad Availability and performs Action
        private void OnAdAvailable(Ad ad)
        {
            switch (ad.AdFormat)
            {
                case AdFormat.REWARDED_VIDEO:
                    _rewardedVideoAd = ad;
                    _isVideoAdAvailable = true;
                    break;
                    //handle other ad formats if needed
            }
        }

        private void OnAdNotAvailable(AdFormat adFormat)
        {
            switch (adFormat)
            {
                case AdFormat.REWARDED_VIDEO:
                    _rewardedVideoAd = null;
                    _isVideoAdAvailable = false;
                    break;
                    //handle other ad formats if needed
            }
        }

        private void OnRequestFail(RequestError error)
        {
            // process error
            UnityEngine.Debug.Log("OnRequestError: " + error.Description);
        }

        private void OnAdStarted(Ad ad)
        {
            switch (ad.AdFormat)
            {
                case AdFormat.REWARDED_VIDEO:
                    _rewardedVideoAd = null;
                    _isVideoAdAvailable = false;
                    break;
                    //handle other ad formats if needed
            }
        }

        private void OnAdFinished(AdResult result)
        {
            switch (result.AdFormat)
            {

                case AdFormat.REWARDED_VIDEO:
                    UnityEngine.Debug.Log("rewarded video closed with result: " + result.Status +
                    "and message: " + result.Message);
                    break;
                    //handle other ad formats if needed
            }
        }

        private void OnCurrencyResponse(VirtualCurrencyResponse response)
        {
            UnityEngine.Debug.Log("Delta of coins: " + response.DeltaOfCoins.ToString() +
                                    ". Transaction ID: " + response.LatestTransactionId +
                                    ".\nCurreny ID: " + response.CurrencyId +
                                    ". Currency Name: " + response.CurrencyName);
        }

        private void OnCurrencyErrorResponse(VirtualCurrencyErrorResponse vcsError)
        {
            UnityEngine.Debug.Log(string.Format("Delta of coins request failed.\n" +
                                "Error Type: {0}\nError Code: {1}\nError Message: {2}",
                                vcsError.Type, vcsError.Code, vcsError.Message));
        }
        #endregion
    }
}