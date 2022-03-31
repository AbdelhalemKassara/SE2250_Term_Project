using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private GameObject item;
    public string getItemName() => itemName;
    public GameObject getItem() => item;//returns the gameobject that this script is attached to
    
}
