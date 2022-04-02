using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public GameObject rightHandGui;
    public GameObject leftHandGui;

    // public GameObject rightHand;
    public GameObject leftHand;
    public TextMeshProUGUI cashTextLabel;
    private int _cash = 0;

    public static Inventory inventory;

    private static List<Item> items = new List<Item>();
    private static Dictionary<Item, Button> buttonMap = new Dictionary<Item, Button>();

    private Weapon equippedSword;
    private GameObject equippedSwordObject;

    public GameObject buttonPrefab;

    private Button equippedButton;

    void Start()
    {
        Item sword = new Sword1();//.thisItem;
        GiveWeapon(sword);
        // GiveSword(LongSword.sword);
    }

    void Awake()
    {
        inventory = this;
    }

    // Gives the player cash.
    public void GiveCash(int cash)
    {
        _cash += cash;
    }

    // Returns true if took cash succesfully,
    // return false if player doesn't have enough cash.
    public bool TakeCash(int cash)
    {
        if (_cash >= cash)
        {
            _cash -= cash;
            return true;
        }
        return false;
    }

    // Returns the current equipped item.
    public Weapon getCurrentSword()
    {
        return equippedSword;
    }

    // Update is called once per frame
    void Update()
    {
        cashTextLabel.text = "Cash: " + _cash;
    }

    // Searches for an equivilent item and returns it.
    private Item FindEquivilentItem(Item item) {
        foreach (Item _item in items ) {
            if (item.Equivalent(item)) return _item;
        }
        return null;
    }


    // Find an equivalent item from the inventory and remove it.
    public void RemoveItem(Item findItem)
    {
        Item item = FindEquivilentItem(findItem);
        if (item == null) return;

        Button button = buttonMap[item];
        items.Remove(item);
        button.gameObject.SetActive(false);
        if (item == equippedSword)
        {
            Destroy(equippedSwordObject);
            equippedSword = null;
            equippedButton = null;
        }
    }

    public void GiveItem(Item item)
    {
        if (item.getType() == "Weapon")
            GiveWeapon(item);
        // TODO: handle giving player other items, if/when we implement other items.
    }

    public Item[] GetItems() => items.ToArray();

    public void GiveWeapon(Item weapon)
    {
        Debug.Log("Giving Weapon " + weapon.GetName());
        Button button = Instantiate(buttonPrefab).GetComponent<Button>();
        button.transform.SetParent(panel.transform, false);
        button.GetComponentInChildren<TextMeshProUGUI>().text = weapon.GetName();

        items.Add(weapon);
        buttonMap[weapon] = button;

        button.onClick.AddListener(
            delegate
            {
                button.gameObject.SetActive(false);
                equipWeapon((Weapon)weapon);
            }
        );
    }
    
    void equipWeapon(Weapon weapon)
    {
        if (equippedSword != null)
        {
            Destroy(equippedSwordObject);
            GiveWeapon(equippedSword);
            equippedButton.gameObject.SetActive(false);
        }

        GameObject rightHand = BodyParts.rightHand;
        if (rightHand == null)
            return;

        equippedSword = weapon;
        equippedSwordObject = weapon.getObject();
        equippedSwordObject.transform.SetParent(rightHand.transform, false);

        Button button = Instantiate(buttonPrefab).GetComponent<Button>();
        button.transform.SetParent(rightHandGui.transform, false);
        button.GetComponentInChildren<TextMeshProUGUI>().text = weapon.GetName();
        buttonMap[weapon] = button;

        equippedButton = button;

        button.onClick.AddListener(
            delegate
            {
                Destroy(equippedSwordObject);
                GiveWeapon(weapon);
                button.gameObject.SetActive(false);
                equippedSword = null;
                equippedButton = null;
            }
        );
    }
}
