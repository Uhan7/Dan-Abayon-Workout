using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dan : MonoBehaviour
{
    public AudioSource sfxSource;

    public AudioClip breatheInSFX;
    public AudioClip breatheOutSFX;

    private Animator RAnim;
    private Animator LAnim;

    public GameObject RArm;
    public GameObject LArm;

    public GameObject RBicep;
    public GameObject LBicep;

    public GameObject RWeight;
    public GameObject LWeight;

    public int RWeights;
    public int LWeights;

    public float RBicepSize;
    public float LBicepSize;

    public float WeightsIncrease;
    public float BicepsIncrease;

    private void Awake()
    {
        RAnim = RArm.GetComponent<Animator>();
        LAnim = LArm.GetComponent<Animator>();
    }

    private void Start()
    {

    }

    void Update()
    {

        RWeight.transform.localScale = new Vector2((2 + RWeights * WeightsIncrease) * 1/RBicep.transform.localScale.x, 5 + RWeights * WeightsIncrease);
        LWeight.transform.localScale = new Vector2((2 + LWeights * WeightsIncrease) * 1 / LBicep.transform.localScale.x, 5 + LWeights * WeightsIncrease);

        RBicep.transform.localScale = new Vector2(1 + (RBicepSize - 31) * BicepsIncrease, 1);
        LBicep.transform.localScale = new Vector2(1 + (LBicepSize - 31) * BicepsIncrease, 1);

        if (!GameMaster.useArrowKeys)
        {
            if (MouseDetector.mouseDetected) return;

            if (Input.GetMouseButtonDown(0)) StartCoroutine(RightGainz(true));
            else if (Input.GetMouseButtonUp(0)) StartCoroutine(RightGainz(false));
            if (Input.GetMouseButtonDown(1)) StartCoroutine(LeftGainz(true));
            else if (Input.GetMouseButtonUp(1)) StartCoroutine(LeftGainz(false));
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) StartCoroutine(RightGainz(true));
            else if (Input.GetKeyUp(KeyCode.LeftArrow)) StartCoroutine(RightGainz(false));
            if (Input.GetKeyDown(KeyCode.RightArrow)) StartCoroutine(LeftGainz(true));
            else if (Input.GetKeyUp(KeyCode.RightArrow)) StartCoroutine(LeftGainz(false));
        }

    }

    IEnumerator RightGainz(bool state)
    {
        RAnim.SetBool("R_Gainz", state);
        if (state) sfxSource.PlayOneShot(breatheInSFX);
        else sfxSource.PlayOneShot(breatheOutSFX);
        yield return new WaitForSeconds(0.1f);
        // <play sfx> ;
    }

    IEnumerator LeftGainz(bool state)
    {
        LAnim.SetBool("L_Gainz", state);
        if (state) sfxSource.PlayOneShot(breatheInSFX);
        else sfxSource.PlayOneShot(breatheOutSFX);
        yield return new WaitForSeconds(0.1f);
        // <play sfx> ;
    }

}
