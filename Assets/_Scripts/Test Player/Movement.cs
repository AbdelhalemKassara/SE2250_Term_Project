using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    private Transform playerTran;

    void Start() {
      //  playerTran = GetComponenet<Transform>();
    }

    void FixedUpdate()
    {
     if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localPosition += new Vector3(0,0,speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localPosition += new Vector3(0,0,-speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localPosition += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
    }

    void rotatePlayer() {
        
    }
}
