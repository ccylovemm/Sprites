using UnityEngine;
using System.Collections;

public class ResourceLoad{

	static public Texture LoadIcon(string name)
	{
		return Resources.Load<Texture>(name);
	}

	static public GameObject LoadWindow(string name)
	{
		return Resources.Load<GameObject>(name);
	}
}
