using UnityEngine;
using System.Collections;

public class DontDestory : MonoBehaviour {
	//作者：曹春阳

	//Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
