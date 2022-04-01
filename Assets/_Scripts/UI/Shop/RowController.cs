using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RowController : MonoBehaviour
{
    private TextMeshProUGUI quantityText;
    private GameObject thisRow;
    [SerializeField] private BuyItems buyItems;
    
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ProcessItem);
        thisRow = gameObject.transform.parent.gameObject;
        quantityText = thisRow.GetComponent<Transform>().Find("Quantity").GetComponent<TextMeshProUGUI>();
        buyItems = thisRow.transform.parent.gameObject.GetComponent<BuyItems>();

    }

    void ProcessItem()
    {
        buyItems.ProcessTransaction(thisRow, this);        
    }

    public void updateQuantity(int quantity)
    {
        if(quantity < 1)
        {
            Destroy(thisRow);
        }
        quantityText.text = 'X' + quantity.ToString();
    }
}
