using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

//  Created by CaoChunYang 

public class VersionManager : Singleton<VersionManager> 
{
	public static readonly string VersionFile = "version.txt";    
	public static readonly string LocalResUrl = "file://" + Application.dataPath + "/Res/";    
	public static readonly string ServerResUrl = "file:///C:/Res/";    
	public static readonly string LocalResPath = Application.dataPath + "/Res/";    

	[HideInInspector]
	public EventDelegate.Callback CheckVersionFinish;

	private Dictionary<string , string> LocalResVersion = new Dictionary<string, string>();   
	private Dictionary<string , string> ServerResVersion = new Dictionary<string, string>();      
	private List<string> NeedDownFiles = new List<string>();  
	private int NeedDownCount = 0;
	private bool NeedUpdateLocalVersionFile = false;    
	
	public void CheckVersion(EventDelegate.Callback OnFinish)    
	{     
		CheckVersionFinish = OnFinish;
		Singleton<Loading>.Instance.UpdateValue(0 , "检查版本");
		StartCoroutine(DownLoad(LocalResUrl + VersionFile, delegate(WWW localVersion)    
        {     
			ParseVersionFile(localVersion.text, LocalResVersion);    
			StartCoroutine(this.DownLoad(ServerResUrl + VersionFile, delegate(WWW serverVersion)      
         	{
				ParseVersionFile(serverVersion.text, ServerResVersion);     
				CompareVersion();   
				NeedDownCount = NeedDownFiles.Count;
				if(NeedDownCount > 0)
				{
					Singleton<Loading>.Instance.UpdateValue(0 , string.Format("更新资源(0/{0})" , NeedDownCount));
				}
				DownLoadRes();    
			}));    
		}));    
	}    
	  
	void DownLoadRes()    
	{    
		if (NeedDownFiles.Count == 0)    
		{    
			UpdateLocalVersionFile();    
			return;    
		}    

		string file = NeedDownFiles[0];    
		NeedDownFiles.RemoveAt(0);    

		StartCoroutine(this.DownLoad(ServerResUrl + file, delegate(WWW w)    
      	{      
			ReplaceLocalRes(file, w.bytes);   
			Singleton<Loading>.Instance.UpdateValue((float)(NeedDownCount - NeedDownFiles.Count) / (float) NeedDownCount , string.Format("更新资源({0}/{1})" , NeedDownCount - NeedDownFiles.Count ,  NeedDownCount));
			DownLoadRes();    
		}));    
	}    
	
	void ReplaceLocalRes(string fileName, byte[] data)    
	{    
		string filePath = LocalResUrl + fileName;    
		FileStream stream = new FileStream(LocalResPath + fileName, FileMode.Create);    
		stream.Write(data, 0, data.Length);    
		stream.Flush();    
		stream.Close();    
	}     

	void UpdateLocalVersionFile()    
	{    
		if (NeedUpdateLocalVersionFile)    
		{    
			StringBuilder versions = new StringBuilder();    
			foreach (var item in ServerResVersion)    
			{    
				versions.Append(item.Key).Append(",").Append(item.Value).Append("\n");    
			}    
			FileStream stream = new FileStream(LocalResPath + VersionFile, FileMode.Create);    
			byte[] data = Encoding.UTF8.GetBytes(versions.ToString());    
			stream.Write(data, 0, data.Length);    
			stream.Flush();    
			stream.Close();    
		}     

		if (CheckVersionFinish != null) {
			CheckVersionFinish ();
		}
	}    
	
	void CompareVersion()    
	{    
		foreach (var version in ServerResVersion)    
		{    
			string fileName = version.Key;    
			string serverMd5 = version.Value;    

			if (!LocalResVersion.ContainsKey(fileName))    
			{    
				NeedDownFiles.Add(fileName);    
			}    
			else    
			{    
				string localMd5;    
				LocalResVersion.TryGetValue(fileName, out localMd5);    
				if (!serverMd5.Equals(localMd5))    
				{    
					NeedDownFiles.Add(fileName);    
				}    
			}    
		}    
		NeedUpdateLocalVersionFile = NeedDownFiles.Count > 0;    
	}    
	
	void ParseVersionFile(string content, Dictionary<string , string> dict)    
	{    
		if (content == null || content.Length == 0)    
		{    
			return;    
		}    
		string[] items = content.Split('\n');    
		foreach (string item in items)    
		{    
			string[] info = item.Split(',');    
			if (info != null && info.Length == 2)    
			{    
				dict.Add(info[0], info[1]);    
			}    
		}    
	}    
	
	IEnumerator DownLoad(string url, HandleFinishDownload finishFun)    
	{    
		WWW www = new WWW(url);    
		yield return www;    
		if (finishFun != null)    
		{    
			finishFun(www);    
		}    
		www.Dispose();    
	}    
	
	public delegate void HandleFinishDownload(WWW www);    
}  