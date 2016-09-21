using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//  Created by CaoChunYang 

public class SceneActor : MonoBehaviour {

	private SceneAction currAction;
	private SceneActorState currState;
	private NavMeshAgent navMeshAgent;
	private List<SceneAction> actionList = new List<SceneAction>();

	void Update()
	{
		if(navMeshAgent.remainingDistance > 0)
		{
			currState = SceneActorState.Move;
		}
	}

	public void SetAction(Vector3 tarPos , EventDelegate.Callback call = null)
	{
		ClearAction();
		SceneAction action = new SceneAction();
		action.pos = tarPos;
		action.call = call;
		actionList.Add(action);
		DoNextAction();
	}

	public void AddAction(Vector3 tarPos , EventDelegate.Callback call = null)
	{
		SceneAction action = new SceneAction();
		action.pos = tarPos;
		action.call = call;
		actionList.Add(action);
	}

	private void DoNextAction()
	{
			currAction = actionList[0];
			actionList.RemoveAt(0);
			navMeshAgent.SetDestination(currAction.pos);
	}

	private void ClearAction()
	{
		actionList.Clear();
		navMeshAgent.Stop();
	}
}

public struct SceneAction
{
	public Vector3 pos;
	public EventDelegate.Callback call;
}
