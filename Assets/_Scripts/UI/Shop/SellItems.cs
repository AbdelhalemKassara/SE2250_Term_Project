using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellItems : StoreManager
{
    private BuyItems buyItems;

    //test code (delete later)
    private void Start()
    {
        AddRow(new ItemQuant(new Sword1(), 3), playerItems);

    }

    protected override bool ProcessFunds(int reqAmount)
    {
        Inventory.inventory.GiveCash(reqAmount);
        return true;
    }

    public override void ProcessTransaction(GameObject row)
    {
        ItemQuant playerItemQuant;
        if(playerItems.TryGetValue(row, out playerItemQuant))
        {
            ProcessFunds(playerItemQuant.GetItemValue());
            Inventory.inventory.RemoveItem(playerItemQuant.GetItem());
            AddBuyMenuItem(playerItemQuant.GetItem());//adds the item to the buy section of the store
            DecQuantity(row, playerItemQuant);//updates the sell portion of the store
                       
        }

    }

    public void AddItemsFromPlayerInventory()
    {
        Item[] inventory = Inventory.inventory.GetItems();

        //insert the new items
        foreach(Item item in inventory)
        {
            ItemQuant itemQuant = GetItemQuantFromPlayerItems(item);

            if(itemQuant == null)
            {
                AddSellMenuItem(item);
            } else
            {
                itemQuant.IncQuantity();
            }

        }
    }
    private ItemQuant GetItemQuantFromPlayerItems(Item item)
    {
        foreach(KeyValuePair<GameObject, ItemQuant> entry in playerItems)
        {
            if(entry.Value.GetItem().Equivalent(item))
            {
                return entry.Value;
            }
        }

        return null;
    }

    public void ClearPlayerItems()
    {
        foreach (KeyValuePair<GameObject, ItemQuant> entry in playerItems)
        {
            Destroy(entry.Key);//removes all the rows
        }
        playerItems = new Dictionary<GameObject, ItemQuant>();
    }
}
