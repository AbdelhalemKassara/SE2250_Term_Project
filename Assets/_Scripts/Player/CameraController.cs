using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CameraController : MonoBehaviour

{
  public GameObject player;

  float upAngle = 0;
  float maxUpAngle = 85;
  float minUpAngle = -85;

  float distance = 5f;
  float minDistance = 1;
  float maxDistance = 7;

  // Start is called before the first frame update
  void Start(){}

  float getUpDistance() {
    return Mathf.Sin(upAngle * Mathf.Deg2Rad) * distance;
  }

  // Update is called once per frame
  void LateUpdate()
  {
    distance += Input.mouseScrollDelta.y * 0.1f;
    distance = distance > maxDistance ? maxDistance : distance;
    distance = distance < minDistance ? minDistance : distance;
    
    upAngle = upAngle > maxUpAngle ? maxUpAngle : upAngle;
    upAngle = upAngle < minUpAngle ? minUpAngle : upAngle;

    Vector3 headOffset = new Vector3(0,1.5f,0);
    transform.localPosition = player.GetComponent<Transform>().position + headOffset + Vector3.Normalize(new Vector3(0, getUpDistance(), 0) - player.GetComponent<Transform>().forward * distance) * distance;
    transform.LookAt(player.GetComponent<Transform>().position + headOffset);
  }

  void OnGUI()
  {
    Event e = Event.current;
    if (e.isMouse)
    {
      upAngle += e.delta.y * 0.5f;
      Debug.Log("up angle: " + upAngle);
    }
  }
}
