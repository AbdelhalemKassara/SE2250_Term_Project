using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellItems : StoreManager
{
    private BuyItems buyItems;

    protected override bool ProcessFunds(int reqAmount)
    {
        //give funds to player
        return true;
    }

    public override void ProcessTransaction(GameObject row, RowController purchaseController)
    {
        //remove item from player
        //add the item to the buy section of the store
    }

}
