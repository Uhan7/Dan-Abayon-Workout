using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameMaster : MonoBehaviour
{
    private int RGain;
    private int LGain;

    public int gainzMultiplier = 1;

    public static int gainz = 0;

    public TextMeshProUGUI gainzText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI weightsText;
    public TextMeshProUGUI sizeText;

    public GameObject dan;
    public Dan danScript;

    public static bool useArrowKeys;

    public void Awake()
    {
        danScript = dan.GetComponent<Dan>();
    }

    public void Start()
    {

    }

    public void Update()
    {
        RGain = (int)(danScript.RWeights * (danScript.RBicepSize - 30));
        LGain = (int)(danScript.LWeights * (danScript.LBicepSize - 30));

        gainzText.text = "Gainz : " + gainz.ToString();
        multiplierText.text = "Gainz Multiplier: " + gainzMultiplier.ToString() + "x";
        weightsText.text = "Weights : " + danScript.RWeights.ToString() + " lb | " + danScript.LWeights.ToString() + " lb";
        sizeText.text = "Bicep Size : " + danScript.RBicepSize.ToString() + " cm | " + danScript.LBicepSize.ToString() + " cm";

        if (MouseDetector.mouseDetected) return;

        if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1) ||
            Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            gainz += (LGain + RGain) * 10 * gainzMultiplier;
        }
        else if (Input.GetMouseButtonDown(0) && !useArrowKeys || Input.GetKeyDown(KeyCode.LeftArrow) && useArrowKeys)
        {
            gainz += RGain * gainzMultiplier;
        }
        else if (Input.GetMouseButtonDown(1) && !useArrowKeys || Input.GetKeyDown(KeyCode.RightArrow) && useArrowKeys)
        {
            gainz += LGain * gainzMultiplier;
        }
    }

    public void UseArrowKeysButton()
    {
        if (!useArrowKeys) useArrowKeys = true;
        else if (useArrowKeys) useArrowKeys = false;
    }

}
