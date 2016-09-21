using UnityEngine;
using System.Collections;

public class AdaptScreen : MonoBehaviour {

	public enum AdaptStyle
	{
		Perfect,
		Full,
		All,
	}

	public int WindowWight = 962;
	public int WindowHeight = 606;
	
	public AdaptStyle adaptStyle = AdaptStyle.Perfect;

	// Use this for initialization
	void Awake () {
		UIRoot root = gameObject.GetComponentInParent<UIRoot>();
		if (root == null)return;

		float s = (float)root.activeHeight / Screen.height;

		int screenWidth = Mathf.CeilToInt(Screen.width * s);
		int screenHeigth = Mathf.CeilToInt(Screen.height * s);

		float screenR = (float)Screen.width / Screen.height;
		float spriteR = (float)WindowWight / WindowHeight;
		float sacle = 1;
		if(adaptStyle == AdaptStyle.Perfect)
		{
			sacle = (screenR > spriteR ?((float)screenHeigth / WindowHeight) : ((float)screenWidth / WindowWight));

		}
		else if(adaptStyle == AdaptStyle.Full)
		{
			sacle = (screenR < spriteR ?((float)screenHeigth / WindowHeight) : ((float)screenWidth / WindowWight));
		}
		transform.localScale = new Vector3(sacle , sacle , sacle);
	}
}
