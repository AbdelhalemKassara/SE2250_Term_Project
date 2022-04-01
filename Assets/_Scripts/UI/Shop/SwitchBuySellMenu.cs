using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchBuySellMenu : MonoBehaviour
{
    [SerializeField] private GameObject buyMenu;
    [SerializeField] private GameObject sellMenu;
    [SerializeField] public TextMeshProUGUI btnText;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SwapWindows);

        //set default values
        sellMenu.SetActive(false);
        buyMenu.SetActive(true);
        btnText.text = "SellMenu";

    }

    void SwapWindows()
    {
        buyMenu.SetActive(!buyMenu.activeSelf);
        sellMenu.SetActive(!buyMenu.activeSelf);//makes sure that sell menu is opposite of buy menu (prevent it from going into a state where both display at the same time)
        btnText.text = buyMenu.activeSelf ? "SellMenu" : "BuyMenu";

    }

}
