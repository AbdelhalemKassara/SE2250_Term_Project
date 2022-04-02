using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected string itemName;
    [SerializeField] protected GameObject item;
    [SerializeField] protected int value;

    protected static Item thisItem;

    protected string type = "Weapon";

    protected static Dictionary<string, Item> itemMap = new Dictionary<string, Item>();

    void Awake() {
        // if (itemMap[GetName] != null) return;
        // thisItem = this;
        if (itemMap.ContainsKey(GetName())) return;
        itemMap[GetName()] = this;
    }

    public string GetName() => itemName;
    public GameObject GetItem() => item;//returns the gameobject that this script is attached to
    public GameObject getObject() => (GameObject)Instantiate(itemMap[GetName()].item, Vector3.zero, Quaternion.identity);

    public string getType() => type;

    public int GetValue() => value;

    
    public virtual bool Equivalent(object obj)
    {
        return Equals(obj);
    }

}