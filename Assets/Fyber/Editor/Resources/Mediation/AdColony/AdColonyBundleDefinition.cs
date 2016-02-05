using UnityEditor;
using UnityEngine;
using System;

namespace FyberEditor
{

	[Serializable]
	[BundleDefinitionAttribute("AdColony", "com.fyber.mediation.adcolony.AdColonyMediationAdapter", "2.3.0-r3", 3)]
	public class AdColonyBundleDefinition : BundleDefinition
	{
		
		[SerializeField]
		[FyberPropertyAttribute("app.id")]
		private string AppId;

		[SerializeField]
		[FyberPropertyAttribute("zone.ids.rewarded.video")]
		private string ZoneIdsRewardedVideo;

		[SerializeField]
		[FyberPropertyAttribute("zone.ids.interstitial")]
		private string ZoneIdsInterstitial;

		[SerializeField]
		[FyberPropertyAttribute("client.options")]
		private string ClientOptions;

	}

}
