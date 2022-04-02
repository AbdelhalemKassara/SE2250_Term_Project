using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected string itemName;
    [SerializeField] protected GameObject item;
    [SerializeField] protected int value;

    public static Item thisItem;

    protected string type = "Weapon";

    void Awake() {
        thisItem = this;
    }

    public string GetName() => itemName;
    public GameObject GetItem() => item;//returns the gameobject that this script is attached to
    public GameObject getObject() => (GameObject)Instantiate(item, Vector3.zero, Quaternion.identity);

    public string getType() => type;

    public int GetValue() => value;
    
}