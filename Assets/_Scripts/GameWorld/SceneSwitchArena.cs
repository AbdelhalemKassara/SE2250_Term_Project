using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchArena : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject boss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && boss == null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
