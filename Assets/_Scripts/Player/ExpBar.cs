using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBar : MonoBehaviour
{
    public Transform panel; // Reference to the panel transform.

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();
        // panelRectTransform.Scale.Set(PlayerStats.stats.getHealthPercentage(), panelRectTransform.Scale.y);
        panelRectTransform.localScale = new Vector3(
            PlayerStats.stats.getExpPercentage(),
            1.0f,
            1.0f
        ); //This works

        Debug.Log("Exp %: " + PlayerStats.stats.getExpPercentage());
        // xPos is the placement of the components.
    }
}
