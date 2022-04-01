using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyItems : MonoBehaviour
{
    [SerializeField] private GameObject menuRow;
    [SerializeField] private GameObject player;


    private void Start()
    {
        //adds the sword and longs sword to the dictionary
        Item ls = new LongSword1();
        Item s = new Sword1();
        addRow(ls, 3);
        addRow(s, 3);
        
    }

    private void addRow(Item item, int quantity)
    {
        GameObject row = Instantiate(menuRow);
        row.GetComponent<Transform>().Find("Item Name").GetComponent<TextMeshProUGUI>().text = item.GetName();
        row.GetComponent<Transform>().Find("Price").GetComponent<TextMeshProUGUI>().text = '$' + item.GetValue().ToString();
        row.GetComponent<Transform>().Find("Quantity").GetComponent<TextMeshProUGUI>().text = 'X' + quantity.ToString();
        row.transform.parent = gameObject.transform;
        
    }
   
}


public class ItemSet
{
    private Item item;
    private int quantity;

    public ItemSet(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }

    public Item GetItem() => item;
    public int GetQuantity() => quantity;

    public void DecQuantity() 
    {
        quantity--;
    }
}
