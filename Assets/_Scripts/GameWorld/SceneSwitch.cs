using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject arean2Trigger;

    private static bool passArena1 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
            passArena1 = true;
            //CharacterSelection.Respawn();
        }
        
    }

    private void Update()
    {

        arean2Trigger.SetActive(passArena1);
    }

}
