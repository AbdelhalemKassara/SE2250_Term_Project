using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody _rigidBody;
    private Animator _animator;
    private bool _attacking = false;

    private IAttacks _attack = new MercenaryAttacks();

    private bool rightButtonDown = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _player = gameObject;
        _rigidBody = GetComponent<Rigidbody>();
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

        Vector3 vel = Vector3.Normalize(move) * speed;
        _rigidBody.velocity = new Vector3(vel.x, _rigidBody.velocity.y, vel.z);

        // _rigidBody.velocity = Vector3.Normalize(move) * speed;
        // _rigidBody.velocity = Vector3.Normalize(move) * speed;
        // _rigidBody.AddForce(Vector3.Normalize(move), ForceMode.VelocityChange);

        // Vector3 vel = Vector3.Normalize(move);// * speed;
        // vel.y = _rigidBody.velocity.y;
        // _rigidBody.AddForce(vel - _rigidBody.velocity, ForceMode.VelocityChange);

        // float velocityZ = Vector3.Dot(move.normalized, transform.forward);
        // float velocityX = Vector3.Dot(move.normalized, transform.right);

        if (move.magnitude > 0)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }

        // transform.Translate(move.normalized * speed * Time.deltaTime, Space.World);

        // _animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        // _animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);

        // Rotate Player
        rightButtonDown = Input.GetMouseButtonDown(1) &&! IsPointerOverUIObject();

        HandleAttacks();
    }

    void HandleAttacks()
    {
        if (_attacking)
            return;

        //Send the message to the Animator to activate the trigger parameter named "Jump"
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
        {
            // Debug.Log("Pressed primary button.");
            _attack.BasicAttack(_animator);
            StartCoroutine(StartAttackDebounce());

            return;
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            _attack.Attack1(_animator);
            StartCoroutine(StartAttackDebounce());

            return;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            _attack.Attack2(_animator);
            StartCoroutine(StartAttackDebounce());
            return;
        }
    }

    IEnumerator StartAttackDebounce()
    {
        _attacking = true;

        //yield on a new YieldInstruction that waits for .5 seconds.
        yield return new WaitForSeconds(.5f);

        //After we have waited .5 seconds print the time again.

        _attacking = false;
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isMouse && !IsPointerOverUIObject())
        {
            // Debug.Log(e.delta);
            _player.transform.Rotate(new Vector3(0, e.delta.x * 0.5f, 0));
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

public interface IAttacks
{
    void BasicAttack(Animator animator);
    void Attack1(Animator animator);
    void Attack2(Animator animator);
}
