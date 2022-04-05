using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Combat : MonoBehaviour
{
     
    public int points;
    public float maxHealth;
    private float health;
    public int attackPower;
    public float btwnAttacksTime;
    public Slider healthBar;
    private float nextAttackTime;
    public static GameObject[] enemies;

    public float swordProb;
    public float longSwordProb;

    private bool isEnemyDead = false;

    // Start is called before the first frame update

    void Start()
    {
        //makes sure the probability of the sword is less than the long sword
        longSwordProb = swordProb < longSwordProb ? longSwordProb : swordProb;

        healthBar.minValue = 0;
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        nextAttackTime = Time.time + btwnAttacksTime;    
        enemies = GameObject.FindGameObjectsWithTag("Enemy");    
    }

    public Vector3 getPosition() {
        return transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<EnemyMovement>().canAttack() && nextAttackTime <= Time.time && !isEnemyDead)
        {
            //call user script for damaging player
            PlayerStats.stats.DamagePlayer(attackPower);
            GetComponent<Animation>().Attack();
            nextAttackTime = Time.time + btwnAttacksTime;
        }
    }

    public void damageEnemy(float damage)
    {
        health -= damage;

        if(health < 0)
        {
           enemyDeath();
        }

        healthBar.value = health;
    }

    public void enemyDeath()
    {
        isEnemyDead = true;

        float prob = Random.Range(0f, 1f);
        if(prob < swordProb)
        {
            Inventory.inventory.GiveWeapon(new Sword1());

        }
        else if(prob < longSwordProb)
        {
            Inventory.inventory.GiveWeapon(new LongSword1());

        }

        PlayerStats.stats.GiveExp(points);
        PlayerStats.stats.GiveHealth((int)((int)points/2));

        StartCoroutine(DestroyGameObject());
    }

    IEnumerator DestroyGameObject()
    {
        GetComponent<Animation>().Die();

        yield return new WaitForSeconds(GetComponent<Animation>().getDeathAnimationTime());
        Destroy(gameObject);

    }

    public bool getIsEnemyDead()
    {
        return isEnemyDead;
    }

}
