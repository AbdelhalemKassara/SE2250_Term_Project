using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Button mercenaryButton;
    public Button archerButton;
    public Button magicianButton;
    public GameObject menu;
    public Object mercenaryPrefab;
    public Object archerPrefab;
    public Object magicianPrefab;
    private static GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        mercenaryButton.onClick.AddListener(
            delegate
            {
                Debug.Log("Mercenary Selected");
                player = (GameObject)Instantiate(mercenaryPrefab, getSpawnLocation(), Quaternion.identity);
                closeMenu();
            }
        );
        archerButton.onClick.AddListener(
            delegate
            {
                Debug.Log("Mercenary Selected");
                closeMenu();
            }
        );
        magicianButton.onClick.AddListener(
            delegate
            {
                Debug.Log("Mercenary Selected");
                closeMenu();
            }
        );
    }

    Vector3 getSpawnLocation()
    {
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("Spawn");
        if (spawns.Length > 0)
            return spawns[0].transform.position;
        return Vector3.zero;
    }

    public static bool isPlayerReady() {
        return player != null;
    }

    public static GameObject getPlayer() {
        return player;
    }

    void closeMenu()
    {
        menu.SetActive(false);
        // Destroy(menu);
    }

    void openMenu()
    {
        menu.SetActive(true);
    }

    // Update is called once per frame
    void Update() { }
}
