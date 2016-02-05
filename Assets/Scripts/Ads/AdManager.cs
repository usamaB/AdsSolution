using UnityEngine;

namespace MS.Ads
{
    [RequireComponent(typeof(KeyGenerator))]
    public class AdManager : MonoBehaviour
    {
        #region Fields & Properties
        [SerializeField]
        private KeysSource _keysSource;
        [SerializeField]
        [HideInInspector]
        private string _fileName;
        [SerializeField]
        [HideInInspector]
        private string _url;
        
        // Source from where to get keys
        public KeysSource Source
        {
            get { return _keysSource; }
            set { _keysSource = value; }
        }
        
        // Web URL from where to get AdKeys
        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }
        
        // FileName from where to get Adkeys e.g adc.json
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        
        // FactoryObject.
        private FyberController _fyberController;
        #endregion

        #region Message Methods
        void Start()
        {            
            GetComponent<KeyGenerator>().GenerateKeys(Source, URL, FileName);
            _fyberController = new FyberController();
            _fyberController.RequestVideoAd();
        }
        #endregion

        #region Methods
        public void ShowAd()
        {
            if (_fyberController.IsVideoAdAvailable)
                _fyberController.ShowVideoAd();
        }
        
        public bool IsVideoAdAvailable()
        {
            return _fyberController.IsVideoAdAvailable ? true : false;
        }
        #endregion
    }
}