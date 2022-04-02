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
    private bool setupSellMenu = true;
    private GameObject panel;

    private void Start()
    {
        panel = transform.Find("Panel").gameObject;
        panel.SetActive(false);
    }

    void Update()
    {
        if(CharacterSelection.isPlayerReady())
        {
            player = CharacterSelection.getPlayer();
        } else
        {
            return;
        }
       if((player.transform.position - storeManagerNPC.transform.position).sqrMagnitude < triggerRadSqr)
        {
            if(setupStore)
            {
                setupStore = false;
                unSetupStore = true;

                panel.SetActive(true);
                
            }
            if (setupSellMenu && sellStore.gameObject.activeSelf)
            {
                setupSellMenu = false;

                sellStore.AddItemsFromPlayerInventory();

            }
        } else
        {
            if(unSetupStore)
            {
                unSetupStore = false;
                setupStore = true;
                setupSellMenu = true;


                sellStore.ClearPlayerItems();
                panel.SetActive(false);
            }
        }   
    }
}
