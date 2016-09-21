using UnityEngine;
using System.Collections;

//  Created by CaoChunYang 

public class CCameraManager : MonoBehaviour {

	private float zoomMin;
	private float zoomMax;
	private float distance;
	private float scrollSpeed;
	private Vector3 oldPos1 = Vector3.zero;
	private Vector3 oldPos2 = Vector3.zero;
	
	private GameObject target;

	void Start()
	{
		distance = (zoomMax + zoomMin) / 2.0f;
	}	

	void Update()
	{
		if (Input.touchCount > 1)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
			{
				Vector3 pos1 = Input.GetTouch(0).position;
				Vector3 pos2 = Input.GetTouch(1).position;
				if (Mathf.Sqrt((pos1.x - pos2.x) * (pos1.x - pos2.x) + (pos1.y - pos2.y) * (pos1.y - pos2.y)) > Mathf.Sqrt((oldPos1.x - oldPos2.x) * (oldPos1.x - oldPos2.x) + (oldPos1.y - oldPos2.y) * (oldPos1.y - oldPos2.y)))
				{
					distance = Mathf.Clamp(distance - 5, zoomMin, zoomMax);
				}
				else
				{
					distance = Mathf.Clamp(distance + 5, zoomMin, zoomMax);
				}
				oldPos1 = pos1;
				oldPos2 = pos2;
			}
		}

		if (target != null)
		{
			Vector3 targetPos = CalTargetPos(gameObject, target);
			var isTweening = (gameObject.transform.position - targetPos).magnitude > 0.02;
			if (isTweening)
			{
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPos, 0.06f);
			}
		}
	}

	public void LookTarget(GameObject value)
	{
		target = value;
		gameObject.transform.position = CalTargetPos(gameObject, target);
	}

	public void FollowTarget(GameObject value)
	{
		target = value;
	}
	
	private Vector3 CalTargetPos(GameObject cameraObj, GameObject target)
	{
		if (target == null) return Vector3.zero;
		Vector3 calPos = new Vector3(0 , 0 , - distance);
		Vector3 position = cameraObj.transform.rotation * calPos + target.transform.position;
		return position;
	}
}
