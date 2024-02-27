using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockablesMaster : MonoBehaviour
{
    public GameObject dan;
    private Dan danScript;

    public GameObject gameMaster;
    private GameMaster gameMasterScript;

    public int[] itemGainzRequirements;
    public GameObject[] items;
    public Button[] itemButtons;
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
        foreach (Button button in itemButtons)
        {
            button.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (GameMaster.gainz >= itemGainzRequirements[i]) itemButtons[i].interactable = true;
        }

        /*
         * if (GameMaster.gainz >= itemGainzRequirements[0]) itemButtons[0].interactable = true;
         * if (GameMaster.gainz >= itemGainzRequirements[1]) itemButtons[1].interactable = true;
         * if (GameMaster.gainz >= itemGainzRequirements[2]) itemButtons[2].interactable = true;
         * if (GameMaster.gainz >= itemGainzRequirements[3]) itemButtons[3].interactable = true;
         * if (GameMaster.gainz >= itemGainzRequirements[4]) itemButtons[4].interactable = true;
         * if (GameMaster.gainz >= itemGainzRequirements[5]) itemButtons[5].interactable = true;
        */
    }

    public void Unlock()
    {
        items[currentObj].SetActive(false);

        if (currentObj >= items.Length-1) return;

        currentObj++;
        items[currentObj].SetActive(true);
    }

    public void Activate()
    {
        switch (currentObj)
        {
            case 1:
                danScript.RWeights += 50;
                danScript.LWeights += 50;
                break;

            case 2:
                danScript.RBicepSize += 8;
                break;

            case 3:
                gameMasterScript.gainzMultiplier *= 4;
                break;

            case 4:
                danScript.RWeights += 40;
                danScript.LWeights += 40;
                danScript.RBicepSize += 4;
                danScript.LBicepSize += 4;
                break;

            case 5:
                gameMasterScript.gainzMultiplier *= 3;
                break;

            case 6:
                gameMasterScript.gainzMultiplier *= 2;
                break;

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
