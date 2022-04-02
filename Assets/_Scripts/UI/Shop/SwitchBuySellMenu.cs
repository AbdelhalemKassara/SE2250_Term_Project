using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchBuySellMenu : MonoBehaviour
{
    [SerializeField] private GameObject buyMenu;
    [SerializeField] private TextMeshProUGUI stateText;

    [SerializeField] private GameObject sellMenu;

    [SerializeField] public TextMeshProUGUI btnText;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SwapWindows);

        //set default values
        buyMenu.SetActive(true);
        sellMenu.SetActive(false);

        btnText.text = "SellMenu";
        stateText.text = "Current Menu: BuyMenu";

    }

    void SwapWindows()
    {
        buyMenu.SetActive(!buyMenu.activeSelf);
        sellMenu.SetActive(!sellMenu.activeSelf);//makes sure that sell menu is opposite of buy menu (prevent it from going into a state where both display at the same time)

        btnText.text = buyMenu.activeSelf ? "SellMenu" : "BuyMenu";
        stateText.text = "Current Menu: " + (!buyMenu.activeSelf ? "SellMenu" : "BuyMenu");
    }

    
}
