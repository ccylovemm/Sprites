using UnityEngine;
using System.Collections;

//  Created by CaoChunYang 

public class AnimationManager : MonoBehaviour {

	private string currAction = "";
	private Animation animation;
	private NavMeshAgent navMeshAgent;

	void Awake()
	{
		animation = GetComponent<Animation> ();
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	void Start()
	{
		animation["stand"].wrapMode = WrapMode.Loop;
		animation["run"].wrapMode = WrapMode.Loop;
		animation["attack01"].wrapMode = WrapMode.Once;
	}

	void Update()
	{
		if(navMeshAgent.remainingDistance > 0)
		{
			Run();
		}
		else
		{
			if(currAction == "run" || !GetComponent<Animation>().isPlaying)
			{
				Idle();
			}
		}
	}

	public void Idle()
	{
		SetAction("stand");
	}

	public void Run()
	{
		SetAction("run");
	}

	public void Attack()
	{
		SetAction("attack01");
	}

	public void SetAttackSpeed(float speed)
	{
		animation.GetClip ("attack01").frameRate = speed;
	}

	private void SetAction(string action)
	{
		if(currAction != action)
		{
			currAction = action;
			GetComponent<Animation>().CrossFade(currAction);
		}
	}
}
