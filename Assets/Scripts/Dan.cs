using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dan : MonoBehaviour
{

    private Animator RAnim;
    private Animator LAnim;

    public GameObject RArm;
    public GameObject LArm;

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

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(RightGainz(true));
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(RightGainz(false));
        }
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(LeftGainz(true));
        }
        else if (Input.GetMouseButtonUp(1))
        {
            StartCoroutine(LeftGainz(false));
        }

    }

    IEnumerator RightGainz(bool state)
    {
        RAnim.SetBool("R_Gainz", state);
        yield return new WaitForSeconds(0.03f);
        //stuff
    }

    IEnumerator LeftGainz(bool state)
    {
        LAnim.SetBool("L_Gainz", state);
        yield return new WaitForSeconds(0.03f);
        //stuff
    }

}
