using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyItems : StoreManager
{
    //key is rows


    private void Start()
    {
        //adds the sword and longs sword to the dictionary
        Item ls = new LongSword1();
        Item s = new Sword1();

        ItemQuant item = new ItemQuant(ls, 3);
        ItemQuant item1 = new ItemQuant(s, 3);

        AddRow(item);
        AddRow(item1);
    }

    protected override bool ProcessFunds(int reqAmount)
    {
        
        //remove funds from player if sufficient then return true else return false
        return true;
    }

    public override void ProcessTransaction(GameObject row, RowController purchaseController)
    {
        ItemQuant itemQuant;
        if(itemsForSale.TryGetValue(row, out itemQuant))
        {
            if(ProcessFunds(itemQuant.GetItemValue())) {
                //give the player the weapon
                itemQuant.DecQuantity();
                purchaseController.updateQuantity(itemQuant.GetQuantity());
            } else
            {
                //do somethign to tell player insufficent funds
            }
        } else
        {
            Debug.Log("error processing transaction");
        }
    }
}



