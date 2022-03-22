using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;

    public void walkForward()
    {
        animator.CrossFade("MK_walk1", 0f);
        
    }
    public void runForward()
    {
        animator.CrossFade("MK_runningForward", 0f);
    }

    public void hitFront()
    {
        animator.CrossFade("Mk_hitfFfront", 0f);
    }

    public void blockAttack()
    {
        animator.CrossFade("MK_blockAttack", 0f);
    }

    public void attack()
    {
        animator.CrossFade("MK_quickSwipe", 0f);
    }

    public void die()
    {
        animator.CrossFade("MK_bigCollapse", 0f);
    }

    public void idle()
    {
        animator.CrossFade("Idle", 0f);
    }
    
}