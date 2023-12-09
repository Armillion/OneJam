using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beamer : Enemy
{

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        //Vector2 playerMaxDir = GetDirToPlayer();
        Vector2 playerMaxDir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);

        playerMaxDir /= Mathf.Max(Mathf.Abs(playerMaxDir.x), Mathf.Abs(playerMaxDir.y));

        if (Mathf.Abs(playerMaxDir.x) < Mathf.Abs(playerMaxDir.y))
        {
            playerMaxDir.x = Mathf.Sign(playerMaxDir.x);
            playerMaxDir.y = -rb.velocity.y;
        }
        else
        {
            playerMaxDir.x = -rb.velocity.x;
            playerMaxDir.y = Mathf.Sign(playerMaxDir.y);
        }
        facingDir = playerMaxDir;
        /*
        //cultist changed direction
        if (lastDir.x != playerMaxDir.x || lastDir.y != playerMaxDir.y)
		{

		}
        */
        Move(facingDir);
    }
}

