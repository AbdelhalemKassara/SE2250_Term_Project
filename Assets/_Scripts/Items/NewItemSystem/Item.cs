using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected string itemName;
    [SerializeField] protected GameObject item;
    [SerializeField] protected int value;
    public string GetName() => itemName;
    public GameObject GetItem() => item;//returns the gameobject that this script is attached to
    public int GetValue() => value;
    
}
