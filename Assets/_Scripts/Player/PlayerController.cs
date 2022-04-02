using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static PlayerController controller;

    private GameObject _player;
    private Rigidbody _rigidBody;
    private static Animator _animator;
    private bool _attacking = false;
    private bool _jumping = false;

    private static IAttacks _attack = new MercenaryAttacks();

    private bool rightButtonDown = false;

    public Vector3 getPosition()
    {
        return transform.position;
    }

    public static void setAttacks(IAttacks attacks)
    {
        // _attack.Idle(_animator);
        _attack = attacks;
    }

    public static IAttacks getAnimations()
    {
        return _attack;
    }

    public static Animator getAnimator()
    {
        return _animator;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        controller = this;
    }

    public void Respawn()
    {
        _attack.Idle(_animator);
    }

    void Start()
    {
        _player = gameObject;
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Check what keys are being pressed to move the player.
    void Update()
    {
        if (PlayerStats.stats.IsDead())
            return;

        Vector3 move = Vector3.zero;
        float speed = 8f;
        float running = 1f;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            running = 1.5f;
        }
        _animator.speed = running;

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

        // Jump when the space bar is pressed.
        if (Input.GetKey(KeyCode.Space))
        {
            if (!_jumping)
            {
                StartCoroutine(StartJumpDebounce());

                if (
                    !(_animator.GetCurrentAnimatorStateInfo(0).IsName("jump"))
                    && !_animator.GetBool("jump")
                )
                    _animator.SetTrigger("jump");
            }
        }

        Vector3 vel = Vector3.Normalize(move) * speed * running;
        _rigidBody.velocity = new Vector3(vel.x, _rigidBody.velocity.y, vel.z);


        if (move.magnitude > 0)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }

        // Rotate Player
        rightButtonDown = Input.GetMouseButtonDown(1) && !IsPointerOverUIObject();

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

    // Debounce to only allow the player to jump once a second.
    IEnumerator StartJumpDebounce()
    {
        _jumping = true;

        //yield on a new YieldInstruction that waits for .5 seconds.
        yield return new WaitForSeconds(1f);

        //After we have waited .5 seconds print the time again.

        _jumping = false;
    }

    void OnGUI()
    {
        if (PlayerStats.stats.IsDead())
            return;

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

    void Death(Animator animator);
    void Swing(Animator animator);
    void Idle(Animator animator);
}
