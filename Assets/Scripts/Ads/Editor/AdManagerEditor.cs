using UnityEditor;

namespace MS.Ads
{
    [CustomEditor(typeof(AdManager))]
    public class _adManagerEditor : Editor
    {
        private KeysSource _keySource;
        private AdManager _adManager;

        public override void OnInspectorGUI()
        {
            // Draws Scripts default inspector.
            DrawDefaultInspector();
            
            // Store the reference to the script. 
            _adManager = (AdManager)target;
            
            // cached becase we want to presist the value.
            _keySource = _adManager.Source;
            
            // Uncomment this if you want Radio Buttons instead of Dropdown for key source.
            // _keySource = (EditorGUILayout.Toggle("Get Keys From Code", (_keySource == KeysSource.Code), EditorStyles.radioButton)) ? KeysSource.Code : _keySource;
            // _keySource = (EditorGUILayout.Toggle("Get Keys From File", (_keySource == KeysSource.File), EditorStyles.radioButton)) ? KeysSource.File : _keySource;
            // _keySource = (EditorGUILayout.Toggle("Get Keys From Web", (_keySource == KeysSource.Web), EditorStyles.radioButton)) ? KeysSource.Web : _keySource;
            
            CreateAdditionalFields(_keySource);
            _adManager.Source = _keySource;            
        }

        // Creates additional fields in the inspector based on the keysource vaule choosen.
        private void CreateAdditionalFields(KeysSource source)
        {
            if (_keySource == KeysSource.File)
            {
                _adManager.URL = string.Empty;
                _adManager.FileName = EditorGUILayout.TextField("Filename", _adManager.FileName);
            }
            else if (_keySource == KeysSource.Web)
            {
                _adManager.FileName = string.Empty;
                _adManager.URL = EditorGUILayout.TextField("URL", _adManager.URL);
            }
            else
            {
                _adManager.FileName = string.Empty;
                _adManager.URL = string.Empty;
            }
        }
    }
}