using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Stats
{
	protected Player player;

	//state machine related stuff
	int state;
	public float waitTimer;
	public int nextState;
	public int requiredState; //if -1 no state required
	private float currentWaitTimer;

	protected override void Start()
	{
		base.Start();
		player = GameObject.FindAnyObjectByType<Player>();

		state = 0;
		nextState = 0;
		waitTimer = 0;
		currentWaitTimer = 0;
		requiredState = -1;
	}

	protected virtual void FixedUpdate()
	{
		//for debugging facing dir
		Debug.DrawLine(transform.position, transform.position + new Vector3(facingDir.x, facingDir.y, 0), new Color(1, 0, 0, 1), 0.1f);
	}
}
