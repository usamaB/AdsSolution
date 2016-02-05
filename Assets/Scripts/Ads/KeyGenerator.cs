using UnityEngine;
using System.Collections;
using MS.Ads.Utility;

namespace MS.Ads
{
    public class KeyGenerator : MonoBehaviour
    {
        // Timeout in seconds
        private const int k_TimeOut = 10;
        
        public void GenerateKeys(KeysSource source, string url, string fileName)
        {
            if (source == KeysSource.File)
                GetKeysFromFile(fileName);
            else if (source == KeysSource.Web)
                GetKeysFromWeb(url);
        }

        // Gets AdKeys from JSON File placed in Resources
        private void GetKeysFromFile(string fileName)
        {

        }

        // Gets AdKeys from Specified URL
        private void GetKeysFromWeb(string url)
        {
            if (Utils.IsNetWorkAvailable())
            {
                var www = new WWW(url);
                StartCoroutine(ExecuteRequest(www));
            }
        }

        private IEnumerator ExecuteRequest(WWW request)
        {
            var timeElapsed = 0.0f;
            var isTimedOut = false;
            while (!request.isDone)
            {
                if (timeElapsed < k_TimeOut)
                {
                    timeElapsed += Time.deltaTime;
                }
                else
                {
                    Debug.LogError("ERROR!! Ads settings call timed out");
                    isTimedOut = true;
                    break;
                }
            }

            if (!isTimedOut && request.error == null)
            {
                // Replace Keys Here
            }
            else
            {
                Debug.LogError(request.error);
                request.Dispose();
                yield return null;
            }
        }
    }
}