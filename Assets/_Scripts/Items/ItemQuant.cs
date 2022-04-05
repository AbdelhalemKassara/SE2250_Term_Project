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
        return item.GetHashCode();
    }
    public override bool Equals(object obj)
    {
        return obj is ItemQuant && item.Equivalent(((ItemQuant)obj).GetItem());     
    }
}