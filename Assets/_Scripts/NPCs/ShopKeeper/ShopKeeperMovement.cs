using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperMovement : Movement
{
    public float lookTriggerRad;
    public float storeTriggerRad;//less than look
    private bool reOpenPlayerUI;

    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject storeUI;

    // Update is called once per frame
    protected void Update()
    {
        base.Update();

        if (playerDirection.magnitude <= lookTriggerRad)
        {
            lookAtPlayer();
            rotateBodyTowardsPlayer();
        }
        else if (playerDirection.magnitude <= storeTriggerRad)
        {
            lookAtPlayer();
            rotateBodyTowardsPlayer();
            OpenStore();

            
        }

     
    }

    private void OpenStore()
    {
        //hide the ui(health, inventory, stats)
        playerUI.SetActive(false);
        storeUI.SetActive(true);

    }

    private void CloseStore()
    {
        storeUI.SetActive(false);
        storeUI.SetActive(false);
    }


}
