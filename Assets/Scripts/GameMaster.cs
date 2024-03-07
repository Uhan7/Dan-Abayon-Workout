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

    public static long gainz = 0;

    public TextMeshProUGUI gainzText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI weightsText;
    public TextMeshProUGUI sizeText;

    public GameObject dan;
    public Dan danScript;

    public bool paused;
    public GameObject pauseMenu;

    public static bool useArrowKeys;

    public void Awake()
    {
        danScript = dan.GetComponent<Dan>();
    }

    public void Start()
    {
        paused = false;
    }

    public void Update()
    {
        //change Dan's arms
        RGain = (int)(danScript.RWeights * (danScript.RBicepSize - 30));
        LGain = (int)(danScript.LWeights * (danScript.LBicepSize - 30));

        //Text stuff
        gainzText.text = "Gainz : " + gainz.ToString();
        multiplierText.text = "Gainz Multiplier: " + gainzMultiplier.ToString() + "x";
        weightsText.text = "Weights : " + danScript.RWeights.ToString() + " lb | " + danScript.LWeights.ToString() + " lb";
        sizeText.text = "Bicep Size : " + danScript.RBicepSize.ToString() + " cm | " + danScript.LBicepSize.ToString() + " cm";

        //Only clickable at certain areas
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

        //Pause Stuff
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void UseArrowKeysButton()
    {
        if (!useArrowKeys) useArrowKeys = true;
        else if (useArrowKeys) useArrowKeys = false;
    }

    public void PauseGame()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            paused = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            paused = false;
        }
    }

}
