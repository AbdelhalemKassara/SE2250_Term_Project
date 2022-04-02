using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePopupController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject storeManagerNPC;
    [SerializeField] private SellItems sellStore;

    [SerializeField] private float triggerRadSqr;

    private bool setupStore = true;
    private bool unSetupStore = false;

    private GameObject panel;

    private void Start()
    {
        panel = transform.Find("Panel").gameObject;
        panel.SetActive(false);
    }

    void Update()
    {
       if((player.transform.position - storeManagerNPC.transform.position).sqrMagnitude < triggerRadSqr)
        {
            if(setupStore)
            {
                panel.SetActive(true);
                sellStore.AddItemsFromPlayerInventory();

                setupStore = false;
                unSetupStore = true;

            }
        } else
        {
            if(unSetupStore)
            {

                sellStore.ClearPlayerItems();
                panel.SetActive(false);

                unSetupStore = false;
                setupStore = true;
            }
        }   
    }
}
