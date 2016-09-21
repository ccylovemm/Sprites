using UnityEngine;
using System.Collections;

public class StaticConfig{
	
	public static readonly string basePath =
		#if UNITY_ANDROID
		"jar:file://" + Application.dataPath + "!/assets/Resources/";
		#elif UNITY_IPHONE
		"file://" + Application.dataPath + "/Raw/Resources/";
		#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
		"file://"+Application.dataPath + "/StreamingAssets/Resources/";
		#else
		string.Empty;
		#endif     
}
