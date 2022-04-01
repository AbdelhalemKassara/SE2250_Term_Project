using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Items { }

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public GameObject rightHandGui;
    public GameObject leftHandGui;
    public GameObject rightHand;
    public GameObject leftHand;
    public TextMeshProUGUI cashTextLabel;
    private int _cash = 0;

    public static Inventory inventory;

    private ISword equippedSword;
    private GameObject equippedSwordObject;

    public GameObject buttonPrefab;

    private Button equippedButton;

    void Start()
    {
        ISword sword = Sword.sword;
        GiveSword(sword);
        // GiveSword(LongSword.sword);
    }

    void Awake()
    {
        inventory = this;
    }

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

    public ISword getCurrentSword()
    {
        return equippedSword;
    }

    // Update is called once per frame
    void Update()
    {
        cashTextLabel.text = "Cash: " + _cash;
    }

    public void GiveSword(ISword sword)
    {
        Button button = Instantiate(buttonPrefab).GetComponent<Button>();
        button.transform.SetParent(panel.transform, false);
        button.GetComponentInChildren<TextMeshProUGUI>().text = sword.getName();

        button.onClick.AddListener(
            delegate
            {
                button.gameObject.SetActive(false);
                equipSword(sword);
            }
        );
    }

    void equipSword(ISword sword)
    {
        if (equippedSword != null)
        {
            Destroy(equippedSwordObject);
            GiveSword(equippedSword);
            equippedButton.gameObject.SetActive(false);
        }

        equippedSword = sword;
        equippedSwordObject = (GameObject)sword.getSwordObject();
        equippedSwordObject.transform.SetParent(rightHand.transform, false);

        Button button = Instantiate(buttonPrefab).GetComponent<Button>();
        button.transform.SetParent(rightHandGui.transform, false);
        button.GetComponentInChildren<TextMeshProUGUI>().text = sword.getName();

        equippedButton = button;

        button.onClick.AddListener(
            delegate
            {
                Destroy(equippedSwordObject);
                GiveSword(sword);
                button.gameObject.SetActive(false);
                equippedSword = null;
                equippedButton = null;
            }
        );
    }
}
