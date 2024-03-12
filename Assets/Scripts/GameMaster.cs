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

    public int gainzMultiplier;

    public static long gainz;

    public float doubleRepTime;
    private float doubleRepTimer;

    private bool canDoubleRep;

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
        gainzMultiplier = 1;
        gainz = 0;

        paused = false;
        doubleRepTimer = 0;
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

        //Double Rep Timer goes down continuously
        doubleRepTimer -= Time.deltaTime;
        Debug.Log(doubleRepTimer);

        //Gainz part
        if (!useArrowKeys)
        {
            if (MouseDetector.mouseDetected) return;

            if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1))
            {
                gainz += (LGain + RGain) * 10 * gainzMultiplier;
                // play epic perfect rep sfx
                // instantiate perfect rep effect
            }
            else if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                if (canDoubleRep)
                {
                    gainz += (LGain + RGain) * 10 * gainzMultiplier;
                    gainz -= (Input.GetMouseButtonDown(0)) ? LGain * gainzMultiplier : RGain * gainzMultiplier;
                    // play epic perfect rep sfx
                    // instantiate perfect rep effect
                }
                else
                {
                    doubleRepTimer = doubleRepTime;
                    gainz += Input.GetMouseButtonDown(0) ? RGain * gainzMultiplier : LGain * gainzMultiplier;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
            {
                gainz += (LGain + RGain) * 10 * gainzMultiplier;
                // play epic perfect rep sfx
                // instantiate perfect rep effect
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (canDoubleRep)
                {
                    gainz += (LGain + RGain) * 10 * gainzMultiplier;
                    gainz -= (Input.GetKeyDown(KeyCode.LeftArrow)) ? LGain * gainzMultiplier : RGain * gainzMultiplier;
                    // play epic perfect rep sfx
                    // instantiate perfect rep effect
                }
                else
                {
                    doubleRepTimer = doubleRepTime;
                    gainz += Input.GetKeyDown(KeyCode.LeftArrow) ? RGain * gainzMultiplier : LGain * gainzMultiplier;
                }
            }
        }

        //Pause Stuff
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void FixedUpdate()
    {
        if (doubleRepTimer > 0) canDoubleRep = true;
        else canDoubleRep = false;
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

    public IEnumerator WinGame()
    {
        // Play gigachad musci then wait
        // Activate gigacahd face then wait
        // Activate win screen !!!!!!
            // win screen has
                 // reset prompt
                 // time taken to be gigachad
        yield return null;
    }

    public IEnumerator ResetGame()
    {
        // have slidey box or someshit to center then wait
        // reset values
        // slidey box will fade out
        yield return null;
    }
}
