using UnityEditor;
using UnityEngine;
using System;

namespace FyberEditor
{

	[Serializable]
	[BundleDefinitionAttribute("Chartboost", "com.fyber.mediation.chartboost.ChartboostMediationAdapter", "6.1.0-r1", 3)]
	public class ChartboostBundleDefinition : BundleDefinition
	{

		[SerializeField]
		[FyberPropertyAttribute("AppId")]
		private string AppId;

		[SerializeField]
		[FyberPropertyAttribute("AppSignature")]
		private string AppSignature;

		[SerializeField]
		[FyberPropertyAttribute("LogLevel")]
		private string LogLevel;

		[SerializeField]
		[FyberPropertyAttribute("CacheRewardedVideo")]
		private bool CacheRewardedVideo;

		[SerializeField]
		[FyberPropertyAttribute("CacheInterstitials")]
		private bool CacheInterstitials;

	}

}
