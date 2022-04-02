using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongSword1 : Weapon
{
    public LongSword1()
    {
        attackPower = 2;
        wear = 1;
        attackPowerMult = 1;
        wearMult = 1;
        itemName = "LongSword";
        value = 20;
    }

    //override hashcode method

    public override bool Equals(object obj)
    {
        if (obj != null && obj is LongSword1)
        {
            LongSword1 s = (LongSword1)obj;
            if (s.getAttack().Equals(attackPower) && s.getWear().Equals(wear) &&
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
