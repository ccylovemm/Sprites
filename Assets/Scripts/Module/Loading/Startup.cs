﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Startup : MonoBehaviour {
	
	void Start () 
	{
		StartCoroutine (LoadScene());
	}

	IEnumerator LoadScene()
	{
		WWW www = new WWW (StaticConfig.basePath + "Scenes/BootAnimation.unity3d");
		yield return www;
		AssetBundle bundle = www.assetBundle;
		SceneManager.LoadSceneAsync ("Loading");
		bundle.Unload (false);
		www.Dispose ();
	}
}