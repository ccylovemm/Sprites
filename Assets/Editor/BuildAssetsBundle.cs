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
	
	[MenuItem("BuildAssetBundle/For PC")]
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
		string str = ReadFile.ReadText(Application.dataPath + "/BuildAssets.txt");
		string[] assets = str.Split ('\n');
		for(int i = 0 ; i < assets.Length ; i ++)
		{
			string[] assetInfo = assets [i].Split ('|');
			if(assetInfo[0] == "1")
			{
				BuildPipeline.BuildPlayer (new string[]{assetInfo [2]} , Application.streamingAssetsPath + "/Resources/Scenes/" + assetInfo [1] , buildTarget , BuildOptions.BuildAdditionalStreamedScenes);
				Debug.Log ("打包资源 " + assetInfo [2]);
			}
		}
		AssetDatabase.Refresh ();
		Debug.Log ("打包完成");
	}
}