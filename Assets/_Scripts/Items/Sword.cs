using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISword
{
    Object getSwordObject();
    string getName();
    int getAttack();
}
public interface IWeapon
{
    int getAttack();
}

public class Sword : MonoBehaviour, ISword //, IWeapon
{
    // private int _attack = 1;
    public Object SwordPrefab;

    public static Sword sword;
    public static string name = "Sword";

    void Awake()
    {
        sword = this;
    }

    void Start() {}

    public Object getSwordObject() => Instantiate(SwordPrefab, Vector3.zero, Quaternion.identity);
    public string getName() => name;
    public int getAttack() => 1;
}
