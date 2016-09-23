using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Startup : MonoBehaviour {

    IEnumerator Start() 
	{
        WWW www = new WWW(StaticConfig.basePath + "Scenes/BootAnimation.unity3d");
        yield return www;
        AssetBundle bundle = www.assetBundle;
        SceneManager.LoadSceneAsync("BootAnimation");
        bundle.Unload(false);
        www.Dispose();
        www = null;
	}
}
