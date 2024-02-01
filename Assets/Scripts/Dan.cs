using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dan : MonoBehaviour
{

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

        if (MouseDetector.mouseDetected) return;

        if (Input.GetMouseButton(0) && !GameMaster.useArrowKeys || Input.GetKey(KeyCode.LeftArrow) && GameMaster.useArrowKeys)
        {
            StartCoroutine(RightGainz(true));
        }
        else
        {
            StartCoroutine(RightGainz(false));
        }
        if (Input.GetMouseButton(1) && !GameMaster.useArrowKeys || Input.GetKey(KeyCode.RightArrow) && GameMaster.useArrowKeys)
        {
            StartCoroutine(LeftGainz(true));
        }
        else
        {
            StartCoroutine(LeftGainz(false));
        }

    }

    IEnumerator RightGainz(bool state)
    {
        RAnim.SetBool("R_Gainz", state);
        yield return new WaitForSeconds(0.1f);
        //stuff
    }

    IEnumerator LeftGainz(bool state)
    {
        LAnim.SetBool("L_Gainz", state);
        yield return new WaitForSeconds(0.1f);
        //stuff
    }

}
