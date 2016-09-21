using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using MiniJSON;

//  Created by CaoChunYang 

public class Loading : Singleton<Loading> {

	public UILabel loadDesc;
	public UILabel progressValue;
	public UISlider progressBar;

	private WWW wwwLoad;
	private AsyncOperation asyncOperation;

	private string[] strDesc = new string[]
	{
		"上阵同缘份的散仙，会有额外增益哦~",
		"保留怒气，可以将怒气保留到下一回合",
	};

	void Start()
	{
		Invoke("CheckVersion" , 0.1f);
	}

	void CheckVersion()
	{
		Reset();
		Singleton<VersionManager>.Instance.CheckVersion(CheckVersionComplete);
	}

	void CheckVersionComplete()
	{
		LoadScene ("");
	}

	void Update()
	{
		if (wwwLoad != null && !wwwLoad.isDone) {	
			UpdateValue (wwwLoad.progress / 2.0f);
		}
		if (wwwLoad != null && wwwLoad.isDone && asyncOperation != null && !asyncOperation.isDone) {
			UpdateValue (asyncOperation.progress / 2.0f + 0.5f);
		}
		if(asyncOperation != null && asyncOperation.isDone)
		{
			UpdateValue (1.0f);
		}
	}

	public void LoadScene(string sceneName)
	{
		StartCoroutine (StartLoadScene (sceneName));
	}

	IEnumerator StartLoadScene(string sceneName)
	{
		Reset();
		if (wwwLoad != null)
			wwwLoad.Dispose ();
		wwwLoad = new WWW (StaticConfig.basePath + sceneName + ".unity3d");
		yield return wwwLoad;
		asyncOperation = SceneManager.LoadSceneAsync (sceneName);
		yield return asyncOperation;
		Close ();
		wwwLoad.Dispose ();
		wwwLoad = null;
		asyncOperation = null;
	}

	public void UpdateValue(float value , string desc = "")
	{
		progressBar.value = value;
		progressValue.text = desc;
	}

	void Reset()
	{
		progressBar.value = 0;
		progressValue.text = "0%";
		gameObject.SetActive(true);
		loadDesc.text = strDesc[Random.Range(0 , strDesc.Length)];
	}

	void Close()
	{
		gameObject.SetActive(false);
	}
}

