using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianAttacks : IAttacks
{
    // public GameObject projectile1;
    // public GameObject projectile2;
    // public GameObject projectile3;
    // public GameObject projectile4;

    public void AttackEnemies(int damage, GameObject projectile)
    {
        // projectile = projectile != null ? projectile: projectile1;
        // Vector3 mouse = PlayerController.GetMousePosition();
        Vector3 look = CharacterSelection.getPlayer().transform.forward;
        Vector3 position = CharacterSelection.getPlayer().transform.position + look + new Vector3(0,1,0);

        Projectile.LaunchProjectile(projectile, position , position + (look * 2), 10);

        // // enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // if (Combat.enemies == null)
        // {
        //     Debug.Log("Combat.enemies is null");
        //     return;
        // }

        // foreach (GameObject enemy in Combat.enemies)
        // {
        //     // GameObject enemy = Combat.enemies[i];
        //     Debug.Log("enemy");
        //     Debug.Log(enemy);

        //     if (!enemy)
        //         continue;

        //     Combat combat = enemy.GetComponent<Combat>();
        //     if (!combat)
        //         continue;

        //     Debug.Log("combat");
        //     Debug.Log(combat);

        //     Vector3 offset = PlayerController.controller.getPosition() - combat.getPosition();

        //     if (offset.magnitude <= 2)
        //     {
        //         Debug.Log("Damage!!");
        //         combat.damageEnemy(damage);
        //     }
        // }
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

        string animationName = "spell";

        if (animator.GetBool(animationName))
            return;
        animator.SetTrigger(animationName);
        AttackEnemies(getDamage(1), CharacterSelection.GetSpell1());
    }

    public void Attack1(Animator animator)
    {
        if (animator.GetBool("kick"))
            return;
        animator.SetTrigger("kick");
        AttackEnemies(getDamage(2), CharacterSelection.GetSpell1());
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
        AttackEnemies(getDamage(3), CharacterSelection.GetSpell1());
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
        AttackEnemies(getDamage(2), CharacterSelection.GetSpell1());
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
