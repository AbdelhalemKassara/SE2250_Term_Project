using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemQuant
{
    private Item item;
    private int quantity;

    public ItemQuant(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }

    public Item GetItem() => item;
    public int GetQuantity() => quantity;
    public int GetItemValue() => item.GetValue();
    public void DecQuantity()
    {
        quantity--;
    }
    public void IncQuantity()
    {
        quantity++;
    }

    public override int GetHashCode()
    {
        //return item.GetHashCode();
        return base.GetHashCode();
    }
    public override bool Equals(object obj)
    {
        if(obj != null && obj is ItemQuant && item.Equals(obj))
        {
            //return true
        }
        //return false;
        return base.Equals(obj);
    }
}