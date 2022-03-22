using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSolver : MonoBehaviour
{
    public Transform body = default;
    public float footSpacing;
    public LayerMask terrainLayer;

    // Start is called before the first frame update
    void Start()
    {
        footSpacing = transform.localPosition.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        //downward raycast to find position on terrain for foot to go

        //this creates a ray pointing down 
        Ray ray = new Ray(body.position + (body.right * footSpacing), Vector3.down);
        Debug.Log(body.right);
        if(Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer.value))
        {
            Vector3 val = info.point;
            val.x = transform.position.x;
            transform.position = val;
        }
    }
}
