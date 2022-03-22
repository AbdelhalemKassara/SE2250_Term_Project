using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public float points;
    public float health;
    public float attackPower;
    public float btwnAttacksTime;

    private float nextAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        nextAttackTime = Time.time + btwnAttacksTime;        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Movenment>().canAttack() && nextAttackTime <= Time.time)
        {
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
    }

    public void enemyDeath()
    {


        Destroy(gameObject);
    }

    
    
}
