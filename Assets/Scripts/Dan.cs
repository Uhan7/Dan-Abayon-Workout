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

    private void Awake()
    {
        RAnim = RArm.GetComponent<Animator>();
        LAnim = LArm.GetComponent<Animator>();
    }

    void Update()
    {

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
