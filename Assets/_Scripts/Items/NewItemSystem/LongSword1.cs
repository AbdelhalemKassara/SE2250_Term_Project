using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongSword1 : Weapon
{
    private void Awake()
    {
        attackPower = 2;
        wear = 1;
        attackPowerMult = 1;
        wearMult = 1;
    }
}
