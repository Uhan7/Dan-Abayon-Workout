using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameMaster : MonoBehaviour
{

    public RectTransform canvasRect;

    public AudioSource sfxSource;
    public AudioSource bgmSource;

    public AudioClip vineBoomSFX; // PROBABLY WILL CHANGE TO A BOOM OBJECT
    public AudioClip breatheInSFX;
    public AudioClip breatheOutSFX;

    public AudioClip gigachadMusic;

    private int RGain;
    private int LGain;

    public int gainzMultiplier;

    public static long gainz;

    public float doubleRepTime;
    private float doubleRepTimer;

    private bool canDoubleRep;

    public GameObject doubleRepEffect;

    public TextMeshProUGUI gainzText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI weightsText;
    public TextMeshProUGUI sizeText;

    public GameObject dan;
    public Dan danScript;

    public GameObject gigachadFace;

    public static bool gameEnd;
    public GameObject winScreen;

    public static bool useArrowKeys;

    public void Awake()
    {
        danScript = dan.GetComponent<Dan>();
    }

    public void Start()
    {
        gameEnd = false;

        gainzMultiplier = 1;
        gainz = 0;

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

        //Gainz part
        if (!useArrowKeys)
        {
            if (MouseDetector.mouseDetected) return;

            if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1))
            {
                gainz += (LGain + RGain) * 5 * gainzMultiplier;
                DoubleRep();
            }
            else if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                if (canDoubleRep)
                {
                    gainz += (LGain + RGain) * 5 * gainzMultiplier;
                    gainz -= (Input.GetMouseButtonDown(0)) ? LGain * gainzMultiplier : RGain * gainzMultiplier;
                    DoubleRep();
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
                gainz += (LGain + RGain) * 5 * gainzMultiplier;
                DoubleRep();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (canDoubleRep)
                {
                    gainz += (LGain + RGain) * 5 * gainzMultiplier;
                    gainz -= (Input.GetKeyDown(KeyCode.LeftArrow)) ? LGain * gainzMultiplier : RGain * gainzMultiplier;
                    DoubleRep();
                }
                else
                {
                    doubleRepTimer = doubleRepTime;
                    gainz += Input.GetKeyDown(KeyCode.LeftArrow) ? RGain * gainzMultiplier : LGain * gainzMultiplier;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (doubleRepTimer > 0) canDoubleRep = true;
        else canDoubleRep = false;
    }

    private void DoubleRep()
    {
        float randomPosx = Random.Range(-600f, -400f);
        float randomPosy = Random.Range(-300f, 250f);

        Vector2 randomPos = new Vector2(randomPosx + 683, randomPosy + 384);

        sfxSource.PlayOneShot(vineBoomSFX);
        Instantiate(doubleRepEffect, randomPos, Quaternion.identity, canvasRect);
    }

    public void UseArrowKeysButton()
    {
        if (!useArrowKeys) useArrowKeys = true;
        else if (useArrowKeys) useArrowKeys = false;
    }

    public IEnumerator WinGame()
    {
    // Play gigachad musci then wait
        bgmSource.Stop();
        bgmSource.PlayOneShot(gigachadMusic);
        yield return new WaitForSeconds(3);
    // Activate gigacahd face then wait + disable possible reps
        gigachadFace.SetActive(true);
        yield return new WaitForSeconds(3);
        // disable possible reps
    // Activate win screen !!!!!!
        winScreen.SetActive(true);
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

    public void Wrapper(string coroutineName)
    {
        StartCoroutine(coroutineName);
    }
}
