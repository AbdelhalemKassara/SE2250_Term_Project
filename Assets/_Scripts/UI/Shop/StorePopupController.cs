using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePopupController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject storeManager;

    [SerializeField] private float triggerRadSqr;

    void Update()
    {
        if((player.transform.position - storeManager.transform.position).sqrMagnitude < triggerRadSqr)
        {
            gameObject.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
