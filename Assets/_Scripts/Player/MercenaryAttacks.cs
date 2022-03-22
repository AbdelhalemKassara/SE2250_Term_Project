using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercenaryAttacks : IAttacks
{
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
        animator.SetTrigger("swordFlip");
    }

}
