using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistMaster : Enemy
{
    private Vector2 lastDir;
    private bool maxAxis;

	protected override void FixedUpdate()
	{
		base.FixedUpdate();

        //Vector2 playerMaxDir = GetDirToPlayer();
        Vector2 playerMaxDir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);

        playerMaxDir /= Mathf.Max(Mathf.Abs(playerMaxDir.x), Mathf.Abs(playerMaxDir.y));

        bool curAxis = false;
        if (Mathf.Abs(playerMaxDir.x) < Mathf.Abs(playerMaxDir.y))
		{
            curAxis = false;
        }
        else
		{
            curAxis = true;
        }
        if (maxAxis != curAxis) //square around player
		{
            if (!curAxis)
			{
                //facingDir = new Vector2(0, -Mathf.Sign(playerMaxDir.x));
                facingDir = new Vector2(Mathf.Sign(playerMaxDir.x), 0);
                
            }
			else
			{
                //facingDir = new Vector2(-Mathf.Sign(playerMaxDir.y), 0);
                facingDir = new Vector2(0, Mathf.Sign(playerMaxDir.y));
            }
		}
        maxAxis = curAxis;
        //facingDir = playerMaxDir;
        /*
        //cultist changed direction
        if (lastDir.x != playerMaxDir.x || lastDir.y != playerMaxDir.y)
		{

		}
        */
        Move(facingDir);


        lastDir = facingDir;
	}
}
