using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
     
    public float points;
    public float maxHealth;
    private float health;
    public int attackPower;
    public float btwnAttacksTime;
    public Slider healthBar;
    private float nextAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.minValue = 0;
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        nextAttackTime = Time.time + btwnAttacksTime;        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Movenment>().canAttack() && nextAttackTime <= Time.time)
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

        //drop items
        Destroy(gameObject);
    }

    
    
}
