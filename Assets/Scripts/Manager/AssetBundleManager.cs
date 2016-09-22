using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AssetBundleManager
{

    public static readonly string basePath =
#if UNITY_ANDROID
		    "jar:file://" + Application.dataPath + "!/assets/Resources/";
#elif UNITY_IPHONE
		    "file://" + Application.dataPath + "/Raw/Resources/";
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
 "file://" + Application.dataPath + "/StreamingAssets/Resources/";
#else
            string.Empty;
#endif

    public static IEnumerator LoadSceneAsync(string sceneName)
    {
       	WWW www = new WWW (basePath + "Scenes/" + sceneName + ".unity3d");
		yield return www;
        SceneManager.LoadSceneAsync("sceneName");     
	    www.assetBundle.Unload (false);
		www.Dispose ();
    }

    public static IEnumerator LoadAssetBundleAsync(string assetName)
    {
        WWW www = new WWW(basePath + assetName + ".unity3d");
        yield return www;
        www.assetBundle.Unload(false);
        www= null;
    }
}