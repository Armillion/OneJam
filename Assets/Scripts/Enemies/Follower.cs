using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : Enemy
{
	[SerializeField]
    protected Enemy leader;
	protected Vector2 leaderDir;

	public float panicRotSpeed;
	public float leaderDist;

	//we have to make sure that follower has same speed as leader
	protected override void Start()
	{
		base.Start();
		leaderDir = new Vector2(0, 0);
		rb.drag = leader.GetComponent<Rigidbody>().drag;
		speed = leader.speed;
		movespeedMulti = leader.movespeedMulti;
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();

		if (leader)
		{
			Vector2 goalPos = new Vector2(leader.transform.position.x, leader.transform.position.y) - leader.facingDir * leaderDist;
			Vector2 goalDir = GetNormToPos(goalPos);
			//Move(goalDir * Mathf.Min(1, Vector2.Distance(new Vector2(transform.position.x, transform.position.y), goalPos)));
			Move(goalDir);

			facingDir = goalDir;
		}
		else //panic mode
		{
			Rotate(Random.Range(-panicRotSpeed, panicRotSpeed));
			Move(facingDir);
		}

	}
}
