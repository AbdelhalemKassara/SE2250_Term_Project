using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Purchase : MonoBehaviour
{
    private TextMeshProUGUI quantityText;
    private GameObject thisRow;
    private GameObject player;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(BuyItem);
        thisRow = gameObject.transform.parent.gameObject;
        quantityText = thisRow.GetComponent<Transform>().Find("Quantity").GetComponent<TextMeshProUGUI>();

    }

    void BuyItem()
    {
        Debug.Log(quantityText.text.Substring(1));
        try
        {
            int quantity = Int32.Parse(quantityText.text.Substring(1));

            if (quantity > 1)
            {
                quantity--;
                quantityText.text = 'X' + quantity.ToString();

                //add the item to the user

                

            } else
            {
                quantity--;
                quantityText.text = 'X' + quantity.ToString();
                //add the item to the user
                Destroy(thisRow);
            }
        } catch (FormatException)
        {
            Debug.Log("issue with converting string to int in store menu when pressing purhcase button");
        }
    }

}
