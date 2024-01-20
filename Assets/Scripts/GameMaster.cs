using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public int weights;
    public float bicepSize;

    private int gain;
    public int gainz = 0;

    public TextMeshProUGUI gainzText;
    public TextMeshProUGUI weightsText;
    public TextMeshProUGUI sizeText;

    public void Awake()
    {
        
    }

    public void Start()
    {

    }

    public void Update()
    {

        gain = (int)(weights * (bicepSize - 30));

        gainzText.text = "Gainz : " + gainz.ToString();
        weightsText.text = "Weights : " + weights.ToString() + "lb";
        sizeText.text = "Bicep Size : " + (bicepSize).ToString() + "cm";

        if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            gainz += gain*10;
        }
        else if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.LeftArrow)) gainz += gain;
        else if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.RightArrow)) gainz += gain;
    }

}
