using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyParts : MonoBehaviour
{
    public static GameObject rightHand;
    public static GameObject leftHand;

    public GameObject myRightHand;
    public GameObject myLeftHand;
    
    void Awake() {
        rightHand = myRightHand;
        leftHand = myLeftHand;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
