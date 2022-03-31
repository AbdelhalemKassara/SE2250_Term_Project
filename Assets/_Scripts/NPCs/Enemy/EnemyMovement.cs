using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
   //double check this class works and fix the stupid naming
    public float triggerWalkRad;
    public float triggerRunRad;//unused for now


    private void Start()
    {
        if(triggerWalkRad > triggerRunRad)
        {
            triggerRunRad = triggerWalkRad;
        }    
    }

    // Update is called once per frame
    protected void Update()
    {
        base.Update();

        calTarget();
        
        if((target - transform.position).magnitude <= offsetDist)
        {
            lookAtPlayer();
            rotateBodyTowardsPlayer();
        }
        else if(playerDirection.magnitude <= triggerWalkRad)
        {
            lookAtPlayer();
            rotateBodyTowardsPlayer();
            moveTowardsPlayer();
        }
        else
        {
            GetComponent<Animation>().Idle();
        }
    }

    public bool canAttack()
    {
        return (target - transform.position).magnitude <= offsetDist;
    }

}
