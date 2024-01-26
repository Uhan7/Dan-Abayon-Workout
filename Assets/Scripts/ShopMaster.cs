using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMaster : MonoBehaviour
{

    public GameObject gameMaster;
    private GameMaster gameMasterScript;

    public int RWeightsCost;
    public int LWeightsCost;

    public int RSizeCost;
    public int LSizeCost;

    public TextMeshProUGUI RWeightsCostText;
    public TextMeshProUGUI LWeightsCostText;

    public TextMeshProUGUI RSizeCostText;
    public TextMeshProUGUI LSizeCostText;

    private void Awake()
    {
        gameMasterScript = gameMaster.GetComponent<GameMaster>();
    }

    private void Start()
    {
        RWeightsCostText.text = "Cost: " + RWeightsCost + " Gainz";
        LWeightsCostText.text = "Cost: " + LWeightsCost + " Gainz";
        RSizeCostText.text = "Cost: " + RSizeCost + " Gainz";
        LSizeCostText.text = "Cost: " + LSizeCost + " Gainz";
    }

    public void Update()
    {
        //gameMasterScript.danScript.RWeight.transform.localScale = new Vector2(gameMasterScript.danScript.RWeight.transform.localScale.x + weightSizeIncrease, gameMasterScript.danScript.RWeight.transform.localScale.y + weightSizeIncrease);
    }

    public void Purchase(int type)
    {
        switch (type)
        {
            case 1:

                if (GameMaster.gainz < RWeightsCost) return;

                gameMasterScript.danScript.RWeights += 5;

                GameMaster.gainz -= RWeightsCost;
                RWeightsCost = (int) (RWeightsCost * 1.2f);
                RWeightsCostText.text = "Cost: " + RWeightsCost + " Gainz";
                break;
            case 2:

                if (GameMaster.gainz < LWeightsCost) return;

                gameMasterScript.danScript.LWeights += 5;

                GameMaster.gainz -= LWeightsCost;
                LWeightsCost = (int)(LWeightsCost * 1.2f);
                LWeightsCostText.text = "Cost: " + LWeightsCost + " Gainz";
                break;
            case 3:

                if (GameMaster.gainz < RSizeCost) return;

                gameMasterScript.danScript.RBicepSize += 0.5f;

                GameMaster.gainz -= RSizeCost;
                RSizeCost = (int)(RSizeCost * 1.2f);
                RSizeCostText.text = "Cost: " + RSizeCost + " Gainz";
                break;
            case 4:

                if (GameMaster.gainz < LSizeCost) return;

                gameMasterScript.danScript.LBicepSize += 0.5f;

                GameMaster.gainz -= LSizeCost;
                LSizeCost = (int)(LSizeCost * 1.2f);
                LSizeCostText.text = "Cost: " + LSizeCost + " Gainz";
                break;

            default:
                break;
        }
    }

}
