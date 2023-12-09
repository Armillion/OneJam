using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Stats
{
	protected Player player;
	[SerializeField]
	private bool showDirection;

	//state machine related stuff
	int state;
	public float waitTimer;
	public int nextState;
	public int requiredState; //if -1 no state required
	private float currentWaitTimer;

	protected override void Start()
	{
		base.Start();
		player = GameObject.FindObjectOfType<Player>();

		state = 0;
		nextState = 0;
		waitTimer = 0;
		currentWaitTimer = 0;
		requiredState = -1;
	}

	protected virtual void FixedUpdate()
	{
		//for debugging facing dir
		if (showDirection)
		{
			Debug.DrawLine(transform.position, transform.position + new Vector3(facingDir.x, facingDir.y, 0), new Color(1, 0, 0, 1), 0.1f);
		}

	}

	//quality of life
	protected Vector2 GetDirToPlayer()
	{
		Vector2 res = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);

		res /= Mathf.Max(Mathf.Abs(res.x), Mathf.Abs(res.y));

		return res;
	}

	protected Vector2 GetPosToPlayer()
	{
		return new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
	}

	protected Vector2 GetNormToPlayer()
	{
		return new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
	}

	//unused
	protected Vector2 GetNormToPos(Vector3 pos)
	{
		return new Vector2(pos.x - transform.position.x, pos.y - transform.position.y).normalized;
	}
}
