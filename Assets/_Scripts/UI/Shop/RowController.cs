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
        GetComponent<Transform>().Find("Button").GetComponent<Button>().onClick.AddListener(ProcessItem);
        quantityText = GetComponent<Transform>().Find("Quantity").GetComponent<TextMeshProUGUI>();
        buyItems = transform.parent.gameObject.GetComponent<BuyItems>();

    }

    void ProcessItem()
    {
        buyItems.ProcessTransaction(gameObject, this);        
    }

    public void updateQuantity(int quantity)
    {
        quantityText.text = 'X' + quantity.ToString();
    }
}
