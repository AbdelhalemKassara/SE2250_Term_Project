using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RowController : MonoBehaviour
{
    private TextMeshProUGUI quantityText;
    [SerializeField] private StoreManager storeManager;
    
    private void Start()
    {
        GetComponent<Transform>().Find("Button").GetComponent<Button>().onClick.AddListener(ProcessItem);
        quantityText = GetComponent<Transform>().Find("Quantity").gameObject.GetComponent<TextMeshProUGUI>();

        storeManager = transform.parent.gameObject.GetComponent<BuyItems>();

        if(storeManager == null)
        {
            storeManager = transform.parent.gameObject.GetComponent<SellItems>();
        }

    }
   
    void ProcessItem()
    {
        storeManager.ProcessTransaction(gameObject);        
    }

    public void updateQuantity(int quant)
    {
        quantityText.text = 'X' + quant.ToString();
    }
}
