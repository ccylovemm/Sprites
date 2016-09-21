using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//  Created by CaoChunYang 

public class CWindowManager : MonoBehaviour {

	static public Dictionary<string, GameObject> windows = new Dictionary<string, GameObject>();
	
	static public void Open(string key)
	{
		if (windows.ContainsKey(key))
		{
			windows[key].SetActive(true);
		}
		else
		{
			windows[key] = NGUITools.AddChild(GameObject.Find("Window") , GameObject.Instantiate(ResourceLoad.LoadWindow(key)));
		}
	}

	static public void Close(string key)
	{
		if (windows.ContainsKey(key))
		{
			windows[key].SetActive(false);
		}
	}
	
	public void CloseAll()
	{
		foreach (GameObject window in windows.Values)
		{
			window.gameObject.SetActive(false);
		}
	}
}
