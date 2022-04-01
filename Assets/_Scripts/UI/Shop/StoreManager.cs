using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class StoreManager : MonoBehaviour
{
    [SerializeField] private GameObject menuRow;
    [SerializeField] protected GameObject player;

    protected static Dictionary<GameObject, ItemQuant> itemsForSale = new Dictionary<GameObject, ItemQuant>();
    public void addItem(Item item)
    {
        //RowController rowController = CheckIfItemExisits(item);

      //  if(row )
        //check if there already is a row that has the item
        //if there is then add it
        //if not then AddRow(new ItemQuant(item, 1));

    }
    public void addItems(ItemQuant items)
    {
        //check if there already is a row that has the item
        //if there is then addThem it
        //if not then AddRow(items);
    }

    private GameObject CheckIfItemExists(Item item)
    {
        foreach(KeyValuePair<GameObject, ItemQuant> entry in itemsForSale)
        {
            if(entry.Value.GetItem().Equals(item))
            {
                return entry.Key;
            }
        }

        return null;
    }

    public void AddRow(ItemQuant itemQuant)
    {
        Item item = itemQuant.GetItem();
        int quantity = itemQuant.GetQuantity();

        GameObject row = Instantiate(menuRow);
        row.GetComponent<Transform>().Find("Item Name").GetComponent<TextMeshProUGUI>().text = item.GetName();
        row.GetComponent<Transform>().Find("Price").GetComponent<TextMeshProUGUI>().text = '$' + item.GetValue().ToString();
        row.GetComponent<Transform>().Find("Quantity").GetComponent<TextMeshProUGUI>().text = 'X' + quantity.ToString();
        row.transform.parent = gameObject.transform;

        itemsForSale.Add(row, itemQuant);
    }

    public abstract void ProcessTransaction(GameObject row, RowController purchaseController);
    protected abstract bool ProcessFunds(int reqAmount);
}
