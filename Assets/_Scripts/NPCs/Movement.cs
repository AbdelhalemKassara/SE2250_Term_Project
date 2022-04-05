using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public GameObject lookingAt;

    public float rotationSpeed;
    public float movenmentSpeed;
    public float invertFace;
    public float offsetDist;

    protected Vector3 target;
    protected Vector3 playerDirection;


   
    protected void Update()
    {
        playerDirection = player.GetComponent<Transform>().position - transform.position;

        playerDirection *= invertFace;//some assets face the opposite direction   
    }

    protected void calTarget() {
        target = player.GetComponent<Transform>().position - invertFace * Vector3.Normalize(playerDirection) * offsetDist;
    }

    protected void lookAtPlayer()
    {
        Vector3 temp = player.GetComponent<Transform>().position;
        temp.y += 1.5f;//temporarly offsets to look at players face
        lookingAt.GetComponent<Transform>().position = temp;
    }

    protected void rotateBodyTowardsPlayer()
    {
        Vector3 direction = Vector3.RotateTowards(transform.forward, playerDirection, rotationSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(direction);
    }
    protected void walkTowardsPlayer()
    {
        //this sets the target position from the player
        transform.position = Vector3.MoveTowards(transform.position, target, movenmentSpeed * Time.deltaTime);
        GetComponent<Animation>().WalkForward();
    }
    protected void runTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, movenmentSpeed * Time.deltaTime);
        GetComponent<Animation>().RunForward();
    }
}
