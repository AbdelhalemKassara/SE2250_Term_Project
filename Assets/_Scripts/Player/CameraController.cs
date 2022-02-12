using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CameraController : MonoBehaviour

{
  public GameObject player;

  float upDistance = 0;
  float minUpOffset = -2;
  float maxUpOffset = 5;

  float distance = 5f;
  float minDistance = 3;
  float maxDistance = 10;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void LateUpdate()
  {
    distance += Input.mouseScrollDelta.y * 0.1f;

    distance = distance > maxDistance ? maxDistance : distance;
    distance = distance < minDistance ? minDistance : distance;

    upDistance = upDistance > maxUpOffset ? maxUpOffset : upDistance;
    upDistance = upDistance < minUpOffset ? minUpOffset : upDistance;



    transform.localPosition = player.GetComponent<Transform>().position + Vector3.Normalize(new Vector3(0, upDistance, 0) - player.GetComponent<Transform>().forward * distance) * distance;
    transform.LookAt(player.GetComponent<Transform>());
  }

  void OnGUI()
  {
    Event e = Event.current;
    if (e.isMouse)
    {
      Debug.Log(e.delta);
      upDistance += e.delta.y * 0.05f;
    }
  }
}
