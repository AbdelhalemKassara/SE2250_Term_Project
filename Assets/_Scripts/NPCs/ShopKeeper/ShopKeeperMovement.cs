using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperMovement : Movement
{
    public float lookTriggerRad;

    // Update is called once per frame
    protected void Update()
    {
        //this gets the player object
        if (CharacterSelection.isPlayerReady())
        {
            player = CharacterSelection.getPlayer();
        }
        else
        {
            return;
        }

        base.Update();

        calTarget();

        if (playerDirection.magnitude <= lookTriggerRad)
        {
            lookAtPlayer();
            rotateBodyTowardsPlayer();
        }
    }

}
