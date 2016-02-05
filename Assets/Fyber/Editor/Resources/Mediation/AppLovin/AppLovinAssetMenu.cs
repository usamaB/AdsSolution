using System;
using UnityEditor;
using UnityEngine;

namespace FyberEditor
{
	public class AppLovinAssetMenu
	{

#if !UNITY_5
		[MenuItem("Fyber/Mediation Assets Generation/AppLovin")]
		public static void GenerateAppLovinAsset()
		{
			var asset = ScriptableObject.CreateInstance<AppLovinBundleDefinition>();
			AssetDatabase.CreateAsset(asset, "Assets/Fyber/Editor/Resources/Mediation/AppLovin/AppLovinFyberBundle.asset");
			AssetDatabase.SaveAssets();
		}

		[MenuItem("Fyber/Mediation Assets Generation/AppLovin", true)]
		public static bool GenerateAppLovinAsset_Validator()
		{
			var asset = Resources.Load<AppLovinBundleDefinition>("Mediation/AppLovin/AppLovinFyberBundle");
			return asset == null;
		}
#endif

	}
}

