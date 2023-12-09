using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rusher : Enemy
{
    public float rotSpeed;

	protected override void FixedUpdate()
	{
		base.FixedUpdate();
		//rotate towards player
		//float dot = Vector2.Dot(facingDir, (player.transform.position - transform.position).normalized);
		float angleDiff = Vector2.SignedAngle(facingDir, new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized);
		Debug.Log(angleDiff);
		if (angleDiff >= 0)
		{
			//Rotate(Mathf.Min(rotSpeed, dot));
			Rotate(rotSpeed);
		}
		else
		{
			//Rotate(Mathf.Max(-rotSpeed, dot));
			Rotate(-rotSpeed);
		}

		//facingDir = (player.transform.position - transform.position).normalized;
		//always move towards player
		Move(facingDir);
	}
}
