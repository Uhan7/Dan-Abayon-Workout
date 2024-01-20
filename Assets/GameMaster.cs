using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMaster : MonoBehaviour
{

    public static int gainz = 0;

    public TextMeshProUGUI gainzText;

    public void Update()
    {

        gainzText.text = "Gainz : " + gainz.ToString();

        if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            gainz += 10;
        }
        else if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.LeftArrow)) gainz++;
        else if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.RightArrow)) gainz++;
    }

}
