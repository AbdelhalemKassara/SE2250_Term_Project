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

        AddRow(item, itemsForSale);
        AddRow(item1, itemsForSale);
    }
   
    protected override bool ProcessFunds(int reqAmount)
    {         
        return Inventory.inventory.TakeCash(reqAmount);
    }

    public override void ProcessTransaction(GameObject row)
    {
        ItemQuant itemQuant;
        if(itemsForSale.TryGetValue(row, out itemQuant))
        {
            if(ProcessFunds(itemQuant.GetItemValue())) {
                Inventory.inventory.GiveItem(itemQuant.GetItem());
                DecQuantity(row, itemQuant);
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