using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationsTranslater : MonoBehaviour
{
    public Animator animator;
    public string walkForward;
    public string runForward;
    public string hitFront;    
    public string idle;

    public void WalkForward()
    {
        animator.CrossFade(walkForward, 0f);

    }

    public void RunForward()
    {
        animator.CrossFade(runForward, 0f);
    }

    public void HitFront()
    {
        animator.CrossFade(hitFront, 0f);
    }

    public void Idle()
    {
        animator.CrossFade(idle, 0f);
    }
}
