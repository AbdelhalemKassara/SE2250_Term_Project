using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBow : Weapon
{
    public GoldBow()
    {
        attackPower = 5;
        wear = 1;
        attackPowerMult = 1;
        wearMult = 1;
        value = 10;
        itemName = "Gold Bow";

    }
    //ovveride hascode method 

    public override bool Equivalent(object obj)
    {
        if (obj != null && obj is GoldBow)
        {
            GoldBow s = (GoldBow)obj;
            return s.getAttack().Equals(attackPower) && s.getWear().Equals(wear) &&
                s.getAttackPowerMult().Equals(attackPowerMult) &&
                s.getWearMult().Equals(wearMult) && s.GetValue().Equals(value) &&
                s.GetName().Equals(itemName);   
        }
        return false;
    }

}
