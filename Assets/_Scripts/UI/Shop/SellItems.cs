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

        AddItemsFromPlayerInventory();
    }

    protected override bool ProcessFunds(int reqAmount)
    {
        //give funds to player
        return true;
    }

    public override void ProcessTransaction(GameObject row)
    {
        ItemQuant playerItemQuant;
        if(playerItems.TryGetValue(row, out playerItemQuant))
        {
            ProcessFunds(playerItemQuant.GetItemValue());
            //remove item from player inventory
            AddItem(playerItemQuant.GetItem());//adds the item to the buy section of the store
            DecQuantity(row, playerItemQuant);//updates the sell portion of the store
                       
        }

    }

    private void AddItemsFromPlayerInventory()
    {
        //get the items from the player's inventory and add them to the
    }

}
