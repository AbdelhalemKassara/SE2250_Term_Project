using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword1 : Weapon
{
    public Sword1()
    {
        attackPower = 1;
        wear = 1;
        attackPowerMult = 1;
        wearMult = 1;
        value = 10;
        itemName = "Sword";

    }
    //ovveride hascode method 

    public override bool Equals(object obj)
    {
        if (obj != null && obj is Sword1)
        {
            Sword1 s = (Sword1)obj;
            if(s.getAttack().Equals(attackPower) && s.getWear().Equals(wear) &&
                s.getAttackPowerMult().Equals(attackPowerMult) &&
                s.getWearMult().Equals(wearMult) && s.GetValue().Equals(value) &&
                s.GetName().Equals(itemName))
            {
                return true;
            }
        }

        return false;
    }

}
