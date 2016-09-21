using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//  Created by CaoChunYang 

public class BuildView : CWindowBase {

	public GameObject itemPrefab;
	public UIGrid itemGrid;
	public List<BuildItem> buildItems = new List<BuildItem>();
	public UIScrollView itemScrollView;

	void OnEnable()
	{

	}

	void OnDisable()
	{

	}
}
