using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMaster : MonoBehaviour
{

    public GameObject gameMaster;
    private GameMaster gameMasterScript;

    public int[] shopItemCost;

    public TextMeshProUGUI RWeightsCostText;
    public TextMeshProUGUI LWeightsCostText;

    public TextMeshProUGUI RSizeCostText;
    public TextMeshProUGUI LSizeCostText;

    public Button[] shopButtons;

    private void Awake()
    {
        gameMasterScript = gameMaster.GetComponent<GameMaster>();
    }

    private void Start()
    {
        RWeightsCostText.text = "Cost: " + shopItemCost[0] + " Gainz";
        LWeightsCostText.text = "Cost: " + shopItemCost[1] + " Gainz";
        RSizeCostText.text = "Cost: " + shopItemCost[2] + " Gainz";
        LSizeCostText.text = "Cost: " + shopItemCost[3] + " Gainz";
    }

    public void Update()
    {
        for (int i = 0; i < shopButtons.Length; i++)
        {
            if (GameMaster.gainz < shopItemCost[i]) shopButtons[i].interactable = false;
            else shopButtons[i].interactable = true;
        }
    }

    public void Purchase(int type)
    {
        switch (type)
        {
            case 1:

                if (GameMaster.gainz < shopItemCost[0]) return;

                gameMasterScript.danScript.RWeights += 5;

                GameMaster.gainz -= shopItemCost[0];
                shopItemCost[0] = (int) (shopItemCost[0] * 1.2f);
                RWeightsCostText.text = "Cost: " + shopItemCost[0] + " Gainz";
                break;
            case 2:

                if (GameMaster.gainz < shopItemCost[1]) return;

                gameMasterScript.danScript.LWeights += 5;

                GameMaster.gainz -= shopItemCost[1];
                shopItemCost[1] = (int)(shopItemCost[1] * 1.2f);
                LWeightsCostText.text = "Cost: " + shopItemCost[1] + " Gainz";
                break;
            case 3:

                if (GameMaster.gainz < shopItemCost[2]) return;

                gameMasterScript.danScript.RBicepSize += 0.5f;

                GameMaster.gainz -= shopItemCost[2];
                shopItemCost[2] = (int)(shopItemCost[2] * 1.2f);
                RSizeCostText.text = "Cost: " + shopItemCost[2] + " Gainz";
                break;
            case 4:

                if (GameMaster.gainz < shopItemCost[3]) return;

                gameMasterScript.danScript.LBicepSize += 0.5f;

                GameMaster.gainz -= shopItemCost[3];
                shopItemCost[3] = (int)(shopItemCost[3] * 1.2f);
                LSizeCostText.text = "Cost: " + shopItemCost[3] + " Gainz";
                break;

            default:
                break;
        }
    }

}
