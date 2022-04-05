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
    private static string _characterType = "Mercenary";

    public string GetCharacterType() => _characterType;

    // public static GameObject getRightHand() {
    //     if (player == null) return null;
    //     return player.transform.Find("Hips/Spine 1/Spine 2/Spine 3/Right Shoulder/Right Arm/Right Forearm/Right Hand").gameObject;
    // }

    // Start is called before the first frame update

    private static CharacterSelection _this;

    void Awake()
    {
        if (_this != null)
            return;
        _this = this;
    }

    void Start()
    {
        mercenaryButton.onClick.AddListener(
            delegate
            {
                Debug.Log("Mercenary Selected");
                _characterType = "Mercenary";

                player = Spawn(mercenaryPrefab);
                closeMenu();
                Inventory.inventory.GiveWeapon(new Sword1());
            }
        );
        archerButton.onClick.AddListener(
            delegate
            {
                Debug.Log("Archer Selected");
                _characterType = "Archer";
                PlayerController.setAttacks(new ArcherAttacks());

                player = Spawn(archerPrefab);
                closeMenu();
                Inventory.inventory.GiveWeapon(new Bow());
            }
        );
        magicianButton.onClick.AddListener(
            delegate
            {
                Debug.Log("Magician Selected");
                _characterType = "Magician";
                PlayerController.setAttacks(new MagicianAttacks());

                player = Spawn(magicianPrefab);
                closeMenu();
                Inventory.inventory.GiveWeapon(new Wand());
            }
        );
    }

    public static void Respawn()
    {
        // if ()
        // Spawn(magicianPrefab);
    }

    private GameObject Spawn(Object prefab)
    {
        return (GameObject)Instantiate(magicianPrefab, getSpawnLocation(), Quaternion.identity);
    }

    Vector3 getSpawnLocation()
    {
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("Spawn");
        if (spawns.Length > 0)
            return spawns[0].transform.position;
        return Vector3.zero;
    }

    public static bool isPlayerReady()
    {
        return player != null;
    }

    public static GameObject getPlayer()
    {
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
