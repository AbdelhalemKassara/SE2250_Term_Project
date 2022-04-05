using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : Weapon
{
    public Wand()
    {
        attackPower = 1;
        wear = 1;
        attackPowerMult = 1;
        wearMult = 1;
        value = 10;
        itemName = "Wand";

    }
    //ovveride hascode method 

    public override bool Equivalent(object obj)
    {
        if (obj != null && obj is Wand)
        {
            Wand s = (Wand)obj;
            return s.getAttack().Equals(attackPower) && s.getWear().Equals(wear) &&
                s.getAttackPowerMult().Equals(attackPowerMult) &&
                s.getWearMult().Equals(wearMult) && s.GetValue().Equals(value) &&
                s.GetName().Equals(itemName);   
        }
        return false;
    }

}
