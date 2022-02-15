using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
  private GameObject _player;
  private bool rightButtonDown = false;

  void Start()
  {
    _player = gameObject;
  }


  // Check what keys are being pressed to move the player.
  void Update()
  {
    Vector3 move = Vector3.zero;
    float speed = 8f;
    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
    {
      move = move - _player.transform.right;
    }

    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    {
      move = move + _player.transform.right;
    }

    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
    {
      move = move + _player.transform.forward;
    }

    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
    {
      move = move - _player.transform.forward;
    }
    _player.transform.position = _player.transform.position + Vector3.Normalize(move) * speed * Time.deltaTime;


    // Rotate Player
    rightButtonDown = Input.GetMouseButtonDown(1);
  }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isMouse )
        {
            Debug.Log(e.delta);
            _player.transform.Rotate(new Vector3(0, e.delta.x * 0.5f, 0));
        }
    }
}
