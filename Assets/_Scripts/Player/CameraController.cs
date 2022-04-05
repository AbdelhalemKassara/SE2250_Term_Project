using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    float upAngle = 0;
    float maxUpAngle = 85;
    float minUpAngle = -85;

    float distance = 3f;
    float minDistance = 1;
    float maxDistance = 7;

    // Start is called before the first frame update
    void Start() { }

    float getUpDistance()
    {
        return Mathf.Sin(upAngle * Mathf.Deg2Rad) * distance;
    }

    // Update is called once per frame
    void LateUpdate()
    {
      if (!CharacterSelection.isPlayerReady()) return;
      player = CharacterSelection.getPlayer();
      
        distance += Input.mouseScrollDelta.y * 0.1f;
        distance = distance > maxDistance ? maxDistance : distance;
        distance = distance < minDistance ? minDistance : distance;

        upAngle = upAngle > maxUpAngle ? maxUpAngle : upAngle;
        upAngle = upAngle < minUpAngle ? minUpAngle : upAngle;

        Vector3 headOffset = new Vector3(0, 1.5f, 0);
        transform.localPosition =
            player.GetComponent<Transform>().position
            + headOffset
            + Vector3.Normalize(
                new Vector3(0, getUpDistance(), 0)
                    - player.GetComponent<Transform>().forward * distance
            ) * distance;
        transform.LookAt(player.GetComponent<Transform>().position + headOffset);
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isMouse && !IsPointerOverUIObject())
        {
            upAngle += e.delta.y * 0.5f;
        }
    }

    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(
            Input.mousePosition.x,
            Input.mousePosition.y
        );
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
