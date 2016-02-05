using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace FyberEditor
{
	
	[Serializable]
	[BundleDefinitionAttribute("AppLovin", "com.fyber.mediation.applovin.AppLovinMediationAdapter", "6.1.5-r1", 3)]
	public class AppLovinBundleDefinition : BundleDefinition
	{

		[SerializeField]
		[FyberPropertyAttribute("verbose.logging")]
		private bool VerboseLogging;

	}

}
