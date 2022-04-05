using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    [SerializeField] protected int attackPower;
    [SerializeField] protected int wear;
    [SerializeField] protected int attackPowerMult;
    [SerializeField] protected int wearMult;

    public int getAttack() => attackPower;
    public int getWear() => wear;
    public int getAttackPowerMult() => attackPowerMult;
    public int getWearMult() => wearMult;

    public void setAttackPowerMult(int attackPowerMult)
    {
        this.attackPowerMult = attackPowerMult;
    }

    public void setWearMult(int wearMult)
    {
        this.wearMult = wearMult;
    }
}
