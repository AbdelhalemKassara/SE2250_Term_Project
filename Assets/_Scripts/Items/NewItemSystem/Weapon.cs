using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    [SerializeField] protected float attackPower;
    [SerializeField] protected float wear;
    [SerializeField] protected float attackPowerMult;
    [SerializeField] protected float wearMult;

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
