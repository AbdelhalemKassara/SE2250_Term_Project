using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercenaryAttacks : IAttacks
{

    public async void AttackEnemies(int damage)
    {

        // enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (Combat.enemies == null) {
            Debug.Log("Combat.enemies is null");
            return;
        }

        foreach(GameObject enemy in Combat.enemies) {
            // GameObject enemy = Combat.enemies[i];
            Debug.Log("enemy");
            Debug.Log(enemy);

            if (!enemy) continue;

            Combat combat = enemy.GetComponent<Combat>();
            if (!combat) continue;

            Debug.Log("combat");
            Debug.Log(combat);

            Vector3 offset = PlayerController.controller.getPosition() - combat.getPosition();
            
            if (offset.magnitude <= 2)
            {
                Debug.Log("Damage!!");
                combat.damageEnemy(damage);
            }
        }
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
        if (animator.GetBool("swordSlash"))
            return;
        animator.SetTrigger("swordSlash");
        AttackEnemies(getDamage(1));
    }

    public void Attack1(Animator animator)
    {
        if (animator.GetBool("kick"))
            return;
        animator.SetTrigger("kick");
        AttackEnemies(getDamage(2));
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
        AttackEnemies(getDamage(3));
    }

    public void Swing(Animator animator)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing"))
            return;
        if (animator.GetBool("swing"))
            return;

        if (
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1
            && !animator.IsInTransition(0)
        )
            return;
        animator.SetTrigger("swing");
        AttackEnemies(getDamage(2));
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
        Debug.Log("trigger idle");
    }
}
