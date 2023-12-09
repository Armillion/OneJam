using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticker : Enemy
{
	[SerializeField]
	protected Enemy leader;
	protected Vector2 leaderDir;

	public float panicRotSpeed;

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
			leaderDir = leader.facingDir;
			facingDir = GetNormToPlayer();
			Move(leaderDir);
		}
		else //panic mode
		{
			Rotate(Random.Range(-panicRotSpeed, panicRotSpeed));
			Move(facingDir);
		}

	}
}
