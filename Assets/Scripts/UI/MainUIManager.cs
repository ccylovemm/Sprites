using UnityEngine;
using System.Collections;

//  Created by CaoChunYang 

public class MainUIManager : MonoBehaviour {

	public GameObject createBtn;

	void Start()
	{
		UIEventListener.Get (createBtn).onClick = OnBtnClick;
	}

	void OnBtnClick(GameObject o)
	{
		if(o == createBtn)
		{

		}
	}
}
