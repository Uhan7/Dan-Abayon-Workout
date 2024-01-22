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

    public static int gainz = 0;

    public TextMeshProUGUI gainzText;
    public TextMeshProUGUI weightsText;
    public TextMeshProUGUI sizeText;

    public GameObject dan;
    public Dan danScript;

    private bool useArrowKeys;

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
        weightsText.text = "Weights : " + danScript.RWeights.ToString() + " | " + danScript.LWeights.ToString() + " lb";
        sizeText.text = "Bicep Size : " + danScript.RBicepSize.ToString() + " | " + danScript.LBicepSize.ToString() + " cm";

        if (MouseDetector.mouseDetected) return;

        if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1) ||
            Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            gainz += (LGain + RGain) * 10;
        }
        else if (Input.GetMouseButtonDown(0) && !useArrowKeys || Input.GetKeyDown(KeyCode.LeftArrow) && useArrowKeys)
        {
            gainz += RGain;
        }
        else if (Input.GetMouseButtonDown(1) && !useArrowKeys || Input.GetKeyDown(KeyCode.RightArrow) && useArrowKeys)
        {
            gainz += LGain;
        }
    }

}
