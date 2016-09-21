using UnityEngine;
using System.Collections;

//  Created by CaoChunYang 

public class PlayerControl : MonoBehaviour {
	
	public GameObject target;

	private NavMeshAgent navMeshAgent;

	void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		if(target == null)return;
		if(UICamera.isOverUI)return;
		if(Input.GetMouseButton(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) 
			{
				if(hit.collider.gameObject.name == "Terrain")
				{
					navMeshAgent.SetDestination(hit.point);
				}
			}
		}
	}

	public void SetTarget(GameObject tar)
	{
		target = tar;
	}
}
