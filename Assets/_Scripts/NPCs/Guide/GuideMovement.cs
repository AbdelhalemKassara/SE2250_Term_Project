using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideMovement : Movement
{
    public float lookTriggerRad;
    [SerializeField] private GameObject walkTo;
    [SerializeField] private GameObject storeUI;
    private float time;

    [SerializeField] private float distStraight1;
    [SerializeField] private float distStraight2;
    private float timeStraight1;
    private float timeStraight2;

    private void Start()
    {
        time = Time.time;
    }
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
        } else
        {

        }


    }
}
