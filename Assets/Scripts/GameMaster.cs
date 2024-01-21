using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameMaster : MonoBehaviour
{
    private int gain;
    public int gainz = 0;

    public TextMeshProUGUI gainzText;
    public TextMeshProUGUI weightsText;
    public TextMeshProUGUI sizeText;

    public GameObject dan;
    private Dan danScript;

    public void Awake()
    {
        danScript = dan.GetComponent<Dan>();
    }

    public void Start()
    {

    }

    public void Update()
    {

        gain = (int)(danScript.weights * (danScript.bicepSize - 30));

        gainzText.text = "Gainz : " + gainz.ToString();
        weightsText.text = "Weights : " + danScript.weights.ToString() + "lb";
        sizeText.text = "Bicep Size : " + (danScript.bicepSize).ToString() + "cm";

        if (MouseDetector.mouseDetected) return;

        if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1) ||
            Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            gainz += gain * 10;
        }
        else if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gainz += gain;
        }
        else if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            gainz += gain;
        }
    }

}
