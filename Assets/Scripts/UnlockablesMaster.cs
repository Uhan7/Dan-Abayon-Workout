using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockablesMaster : MonoBehaviour
{
    public GameObject dan;
    private Dan danScript;

    public GameObject gameMaster;
    private GameMaster gameMasterScript;

    public GameObject[] items;
    public GameObject[] equips;

    private int currentObj;
    private int currentEquip;

    private void Awake()
    {
        danScript = dan.GetComponent<Dan>();
        gameMasterScript = gameMaster.GetComponent<GameMaster>();
    }

    void Start()
    {
        currentObj = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unlock()
    {
        items[currentObj].SetActive(false);
        currentObj++;
        items[currentObj].SetActive(true);
    }

    public void Activate()
    {
        switch (currentObj)
        {
            case 1:
                danScript.RWeights += 30;
                danScript.LWeights += 30;
                break;

            case 2:
                danScript.RBicepSize += 6;
                break;

            case 3:
                gameMasterScript.gainzMultiplier *= 2;
                break;

            //case 1:
            //    danScript.RWeights += 30;
            //    danScript.LWeights += 30;
            //    break;

            //case 1:
            //    danScript.RWeights += 30;
            //    danScript.LWeights += 30;
            //    break;

            //case 1:
            //    danScript.RWeights += 30;
            //    danScript.LWeights += 30;
            //    break;

            default:
                break;
        }
    }

    public void Equip()
    {
        switch (currentObj)
        {
            case 3:
                equips[currentEquip].SetActive(true);
                currentEquip++;
                break;

            case 5:
                equips[currentEquip].SetActive(true);
                currentEquip++;
                break;

            case 6:
                equips[currentEquip].SetActive(true);
                break;

            default:
                break;
        }
    }

}
