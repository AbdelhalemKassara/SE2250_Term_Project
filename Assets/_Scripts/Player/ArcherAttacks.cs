using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttacks : IAttacks
{
    public void AttackEnemies(int damage, GameObject projectile)
    {
        // projectile = projectile != null ? projectile: projectile1;
        // Vector3 mouse = PlayerController.GetMousePosition();
        Vector3 look = CharacterSelection.getPlayer().transform.forward;
        Vector3 position =
            CharacterSelection.getPlayer().transform.position + look + new Vector3(0, 1, 0);

        Projectile.LaunchProjectile(projectile, position, position + (look * 2), 10);
    }

    public int getDamage(int movePower)
    {
        int swordAttack = 1;
        if (Inventory.inventory.getCurrentSword() != null)
        {
            swordAttack += Inventory.inventory.getCurrentSword().getAttack();
        }

        return (int)(movePower + PlayerStats.stats.getStr() * 0.1f + swordAttack);
    }

    public void BasicAttack(Animator animator)
    {
        Debug.Log("trigger idle archer");

        string animationName = "shoot";

        if (animator.GetBool(animationName))
            return;
        animator.SetTrigger(animationName);
        AttackEnemies(getDamage(1), CharacterSelection.GetArrow1());
    }

    public void Attack1(Animator animator)
    {
        if (animator.GetBool("kick"))
            return;
        animator.SetTrigger("kick");
        AttackEnemies(getDamage(1), CharacterSelection.GetArrow1());
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
        AttackEnemies(getDamage(3), CharacterSelection.GetArrow1());
    }

    public void Swing(Animator animator)
    {
        Debug.Log("Archer swing");
        string animationName = "swing";
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
            return;
        if (animator.GetBool(animationName))
            return;

        if (
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1
            && !animator.IsInTransition(0)
        )
            return;
        animator.SetTrigger(animationName);
        AttackEnemies(getDamage(2), CharacterSelection.GetArrow1());
    }

    public void Death(Animator animator)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("death"))
            return;
        if (animator.GetBool("death"))
            return;

        if (
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1
            && !animator.IsInTransition(0)
        )
            return;
        animator.SetTrigger("death");
        Debug.Log("trigger death");
    }

    public void Idle(Animator animator)
    {
        animator.SetTrigger("idle");
        Debug.Log("trigger idle archer");
    }
}
