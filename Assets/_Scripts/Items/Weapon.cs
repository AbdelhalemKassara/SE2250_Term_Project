using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    [SerializeField] private float attackPower;
    [SerializeField] private float wear;
    [SerializeField] private float attackPowerMult;
    [SerializeField] private float wearMult;

    public float getAttackPower() => attackPower;
    public float getWear() => wear;
    public float getAttackPowerMult() => attackPowerMult;
    public float getWearMult() => wearMult;


    public void setAttackPowerMult(float attackPowerMult)
    {
        this.attackPowerMult = attackPowerMult;
    }

    public void setWearMult(float wearMult)
    {
        this.wearMult = wearMult;
    }
}
