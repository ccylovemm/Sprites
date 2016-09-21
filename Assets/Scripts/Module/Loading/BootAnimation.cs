using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BootAnimation : MonoBehaviour {

	void Start () 
	{
		StartCoroutine (LoadScene());
	}

	IEnumerator LoadScene()
	{
		yield return new WaitForSeconds(1.0f);
		WWW www = new WWW (StaticConfig.basePath + "Scenes/Loading.unity3d");
		yield return www;
		AssetBundle bundle = www.assetBundle;
		SceneManager.LoadSceneAsync ("Loading");
		bundle.Unload (false);
		www.Dispose ();
	}
}
