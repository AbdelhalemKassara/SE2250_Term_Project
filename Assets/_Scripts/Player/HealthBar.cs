using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform panel; // Reference to the panel transform.

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();
        panelRectTransform.localScale = new Vector3(
            PlayerStats.stats.getHealthPercentage(),
            1.0f,
            1.0f
        );

    }
}
