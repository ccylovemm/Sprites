using UnityEngine;
using System.Collections;

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

    /*
    public static IEnumerator LoadAssetBundle(string path)
    {

        WWW bundle = new WWW(basePath + path);
        yield return bundle;
        bundle.assetBundle.Load("fdf");

        //var allObjectvol = bundle.        .LoadAll();
        //yield return Instantiate(bundle.assetBundle.mainAsset);
        //bundle.assetBundle.Unload(false);
    }

    public static IEnumerator LoadSceneAsync(string path)
    {
        WWW www = new WWW(AssetBundleManager.basePath + path + ".unity3d");
        Debug.Log(AssetBundleManager.basePath + path + ".unity3d");
        yield return www;
        Debug.Log(www == null);
        var ab = www.assetBundle;
        Debug.Log(ab == null);
        string[] arr = path.Split('/');
        string sceneName = arr[arr.Length - 1];
        Application.LoadLevel(sceneName);
        Logger.Log("Loading " + path);
        //ab.Unload(false);
        //ab = null;
    }

    public static IEnumerator LoadSceneAsync(IObserver<AsyncOperation> observer, string path)
    {
        WWW www = new WWW(AssetBundleManager.basePath + path + ".unity3d");
        yield return www;
        var ab = www.assetBundle;
        string[] arr = path.Split('/');
        string sceneName = arr[arr.Length - 1];
        AsyncOperation ao = Application.LoadLevelAsync(sceneName);
        while (!ao.isDone)
        {
            observer.OnNext(ao);
            yield return new WaitForEndOfFrame();
        }
        ab.Unload(false);
        //ab = null;
        //www.Dispose();
        //www = null;
        observer.OnNext(ao);
        observer.OnCompleted();
    }
    */
}