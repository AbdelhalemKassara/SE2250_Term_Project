using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperMovement : Movement
{
    public float lookTriggerRad;
    public float talkTriggerRad;//less than look
    // Update is called once per frame
    protected void Update()
    {
        base.Update();

        if (playerDirection.magnitude <= lookTriggerRad)
        {
            lookAtPlayer();
            rotateBodyTowardsPlayer();
        }
        else if (playerDirection.magnitude <= talkTriggerRad)
        {
            lookAtPlayer();
            rotateBodyTowardsPlayer();
            TalkToPlayer();
        }
    }

    private void TalkToPlayer()
    {
        //some kind of descision maiking for what to say
    }

}
