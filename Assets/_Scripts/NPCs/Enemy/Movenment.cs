using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movenment : MonoBehaviour
{
    public GameObject player;
    public GameObject lookingAt;

    public float rotationSpeed;
    public float movenmentSpeed;
    public float invertFace;

    public float offsetDist;
    public float triggerDist;


    private Vector3 target;
    private Vector3 playerDirection;
    

    // Start is called before the first frame update
    void Start()
    {
        target = player.GetComponent<Transform>().position - invertFace * Vector3.Normalize(playerDirection) * offsetDist;
    }

    // Update is called once per frame
    void Update()
    {
        playerDirection = player.GetComponent<Transform>().position - transform.position;

        //some of the assets faces are facing the opposite direction
        playerDirection *= invertFace;

        target = player.GetComponent<Transform>().position - invertFace * Vector3.Normalize(playerDirection) * offsetDist;
        //when the player is in range
        float stopDist = (target - transform.position).magnitude;
        if (playerDirection.magnitude <= triggerDist && stopDist > offsetDist)
        {
            lookAtPlayer();
            rotateBodyTowardsPlayer();
            moveTowardsPlayer();
        } else if(stopDist <= offsetDist) 
        {
            lookAtPlayer();
            rotateBodyTowardsPlayer();
        } else
        {
            GetComponent<Animation>().Idle();
        }
    }

    private void lookAtPlayer()
    {
        Vector3 temp = player.GetComponent<Transform>().position;
        temp.y += 1.5f;//temporarly offsets to look at players face
        lookingAt.GetComponent<Transform>().position = temp;
    }

    private void rotateBodyTowardsPlayer()
    {
        Vector3 direction = Vector3.RotateTowards(transform.forward, playerDirection, rotationSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void moveTowardsPlayer()
    {
        //this sets the target position from the player
        transform.position = Vector3.MoveTowards(transform.position, target, movenmentSpeed * Time.deltaTime);
        GetComponent<Animation>().WalkForward();
    }

    public bool canAttack()
    {
        return (target - transform.position).magnitude <= offsetDist;
    }

}
