using UnityEngine;

namespace MS.Ads
{
    [RequireComponent(typeof(KeyGenerator))]
    public class AdManager : MonoBehaviour
    {
        #region Fields & Properties
        [SerializeField]
        private KeysSource _keysSource;
        
        [SerializeField][HideInInspector]
        private string _fileName;
        
        [SerializeField][HideInInspector]
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
        private IAds _platformAdFactory;
        #endregion

        #region Message Methods
        void Start()
        {            
            GetComponent<KeyGenerator>().GenerateKeys(Source, URL, FileName);
            _platformAdFactory = new PlatformFactoryProducer().CreateFactory(Application.platform);
        }
        #endregion

        #region Methods
        public void ShowVideoAd()
        {
            if (_platformAdFactory.IsVideoAdAvailable())
                _platformAdFactory.ShowVideoAd();
        }
        
        public void PreLoadVideoAd()
        {
            _platformAdFactory.PreLoadVideoAd();
        }
        
        public bool IsVideoAdAvailable()
        {
            return _platformAdFactory.IsVideoAdAvailable() ? true : false;
        }
        #endregion
    }
}