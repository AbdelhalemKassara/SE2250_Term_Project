using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongSword : MonoBehaviour, ISword //, IWeapon
{
    // private int _attack = 1;
    public static string name = "Long Sword";

    public Object SwordPrefab;

    public static LongSword sword;

    void Awake()
    {
        sword = this;
    }

    void Start() { }

    public Object getSwordObject() => Instantiate(SwordPrefab, Vector3.zero, Quaternion.identity);

    public string getName() => name;
    public int getAttack() => 2;
}
