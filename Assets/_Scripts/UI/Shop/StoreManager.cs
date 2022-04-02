using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class StoreManager : MonoBehaviour
{
    [SerializeField] private GameObject menuRow;
    [SerializeField] protected GameObject player;
    
    protected static Dictionary<GameObject, ItemQuant> itemsForSale = new Dictionary<GameObject, ItemQuant>();
    protected static Dictionary<GameObject, ItemQuant> playerItems = new Dictionary<GameObject, ItemQuant>();

    public void AddBuyMenuItem(Item item)
    {
        AddItems(new ItemQuant(item, 1), transform.parent.Find("Buy").gameObject.GetComponent<BuyItems>());
    }
    public void AddSellMenuItem(Item item)
    {
        AddItems(new ItemQuant(item, 1), transform.parent.Find("Sell").gameObject.GetComponent<BuyItems>());
    }
    //this adds the item to the Menu of the store
    public void AddItems(ItemQuant items, StoreManager manager)
    {
        GameObject row = CheckIfItemExists(items.GetItem());

        ItemQuant currentItem;

        //if the store is already selling an item it increases it's quantity
        //otherwise it creates a new row
        if (row != null && itemsForSale.TryGetValue(row, out currentItem))
        {
            RowController rowController = row.GetComponent<RowController>();
            rowController.updateQuantity(currentItem.GetQuantity() + items.GetQuantity());
            currentItem.IncQuantity();
        }
        else
        {
            manager.AddRow(items, manager is BuyItems ? itemsForSale : playerItems); //TODO: change this so it would work if additional classes other than BuyItems and SellItems exist
        }
    }

    //Checks if the store has the same item for sale
    //and returns the row that contains that item
    private GameObject CheckIfItemExists(Item item)
    {
        foreach(KeyValuePair<GameObject, ItemQuant> entry in itemsForSale)
        {
            if(entry.Value.GetItem().Equivalent(item))
            {
                return entry.Key;
            }
        }

        return null;
    }

    //this adds a new row to the table
    public void AddRow(ItemQuant itemQuant, Dictionary<GameObject, ItemQuant> dict)
    {
        Item item = itemQuant.GetItem();
        int quantity = itemQuant.GetQuantity();

        GameObject row = Instantiate(menuRow);
        row.GetComponent<Transform>().Find("Item Name").GetComponent<TextMeshProUGUI>().text = item.GetName();
        row.GetComponent<Transform>().Find("Price").GetComponent<TextMeshProUGUI>().text = '$' + item.GetValue().ToString();
        row.GetComponent<Transform>().Find("Quantity").GetComponent<TextMeshProUGUI>().text = 'X' + quantity.ToString();
        row.transform.parent = gameObject.transform;

        dict.Add(row, itemQuant);
    }

    public void DecQuantity(GameObject row, ItemQuant itemQuant)
    {
        itemQuant.DecQuantity();

        if (itemQuant.GetQuantity() > 0)
        {
            row.GetComponent<RowController>().updateQuantity(itemQuant.GetQuantity());
        }
        else
        {
            if (playerItems.ContainsKey(row))
            {
                playerItems.Remove(row);
            }
            else if (itemsForSale.ContainsKey(row))
            {
                itemsForSale.Remove(row);
            }

            Destroy(row);
        }
    }

    
    public abstract void ProcessTransaction(GameObject row);
    protected abstract bool ProcessFunds(int reqAmount);
}
