using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercenaryAttacks : MonoBehaviour, IAttacks
{
    private bool _attacking = false;

    public void BasicAttack(Animator animator)
    {
        if (animator.GetBool("swordSlash"))
            return;
        animator.SetTrigger("swordSlash");
    }

    public void Attack1(Animator animator)
    {
        if (animator.GetBool("kick"))
            return;
        animator.SetTrigger("kick");
    }

    public void Attack2(Animator animator)
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("swordFlip"))
            return;
        if (animator.GetBool("swordFlip"))
            return;

        if (
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1
            && !animator.IsInTransition(0)
        )
            return;
        Debug.Log("swordFlip");
        animator.SetTrigger("swordFlip");
    }

    IEnumerator FinishAttack()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for .5 seconds.
        yield return new WaitForSeconds(.5f);

        //After we have waited .5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        _attacking = false;
    }
}
