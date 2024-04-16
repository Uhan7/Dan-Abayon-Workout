using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IGMenuMaster : MonoBehaviour
{
    public Animator shopUI;
    public Animator optUI;

    private bool shopActive;
    private bool optActive;

    // Text
    public TextMeshProUGUI toggleButtonText;
    public TextMeshProUGUI toggleArrowMouseText;

    // Visuals
    public GameObject mouseIcon;
    public GameObject arrowsIcon;

    private void Start()
    {
        shopActive = false;
        optActive = true;
    }

    private void Update()
    {
        // Inputs
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shopActive = !shopActive;
            optActive = !optActive;

            shopUI.SetBool("Active", shopActive);
            optUI.SetBool("Active", optActive);

            print(shopActive);
            print(optActive);
        }

        // Non-Inputs
        arrowsIcon.SetActive(GameMaster.useArrowKeys);
        mouseIcon.SetActive(!GameMaster.useArrowKeys);

        if (!GameMaster.useArrowKeys)
        {
            toggleArrowMouseText.text = "(Left Arrow and Right Arrow instead of Mouse Buttons)\n\nThis is a good option for mouseless trackpad users:3";
            toggleButtonText.text = "Use Arrow Keys";
        }
        else
        {
            toggleArrowMouseText.text = "(Mouse Buttons instead of Left and Right Arrow keys)\n\nThis is a good option for mouse users:3";
            toggleButtonText.text = "Use Mouse Buttons";
        }

    }
}
