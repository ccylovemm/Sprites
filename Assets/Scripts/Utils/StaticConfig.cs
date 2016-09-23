using UnityEngine;
using System.Collections;

public class StaticConfig{
	
	public static readonly string basePath =
		#if UNITY_ANDROID
		"jar:file://" + Application.dataPath + "!/assets/Resources/Android/";
        #elif UNITY_IPHONE
		"file://" + Application.dataPath + "/Raw/Resources/iOS/";
        #elif UNITY_EDITOR
        "file://" +Application.dataPath + "/StreamingAssets/Resources/Windows/";
		#else
		string.Empty;
		#endif     
}
