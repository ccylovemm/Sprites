using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

//  Created by CaoChunYang 

static class BuildAssetsBundle
{
	static BuildTarget buildTarget;
	static string tarFolderBasePath;
    
	[MenuItem("BuildAssetBundle/For Windows")]
	static void BuildAssetBundleForPC()
	{
		buildTarget = BuildTarget.StandaloneWindows;
        BuildAssetBundle();
	}

	[MenuItem("BuildAssetBundle/For Android")]
	static void BuildAssetBundleForAndroid()
	{
		buildTarget = BuildTarget.Android;
        BuildAssetBundle();
	}

	[MenuItem("BuildAssetBundle/For IPhone")]
	static void BuildAssetBundleForIPhone()
	{
		buildTarget = BuildTarget.iOS;
        BuildAssetBundle();
	}
	
	[MenuItem("BuildAssetBundle/For Mac")]
	static void BuildAssetBundleForMac()
	{
		buildTarget = BuildTarget.StandaloneOSXUniversal;
        BuildAssetBundle();
	}

	static void BuildAssetBundle()
	{
        string outputPath = BuildOutPutPath;

        if (Directory.Exists(outputPath))
        {
            Directory.Delete(outputPath, true);
        }
        Directory.CreateDirectory(outputPath);
        BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, buildTarget);
	/*	string str = ReadFile.ReadText(Application.dataPath + "/BuildAssets.txt");
		string[] assets = str.Split ('\n');
		for(int i = 0 ; i < assets.Length ; i ++)
		{
			string[] assetInfo = assets [i].Split ('|');
			if(assetInfo[0] == "1")
			{
                BuildPipeline.BuildPlayer(new string[] { assetInfo[2] }, outputPath + "Scenes/" + assetInfo[1], buildTarget, BuildOptions.BuildAdditionalStreamedScenes);
				Debug.Log ("打包资源 " + assetInfo [2]);
			}
		}
     * */
		AssetDatabase.Refresh ();
		Debug.Log ("打包完成");
	}


    public static string BuildOutPutPath
    {
        get
        {
            string path = "";
            switch (buildTarget)
            {
                case BuildTarget.Android:
                    path = Application.streamingAssetsPath + "/Resources/Android/";
                    break;
                case BuildTarget.iOS:
                    path = Application.streamingAssetsPath + "/Resources/iOS/";
                    break;
                case BuildTarget.StandaloneWindows:
                    path = Application.streamingAssetsPath + "/Resources/Windows/";
                    break;
                case BuildTarget.StandaloneOSXUniversal:
                    path = Application.streamingAssetsPath + "/Resources/OSX/";
                    break;
            }

            return path;
        }
    }
	
}