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

    public void Purchase(string data)
    {
        data.Split(",");
        int type = (int) data[0]; // 1-rw, 2-lw, 3-rs, 4-ls
        int change = (int) data[1];
        int cost = (int) data[2];

        if (GameMaster.gainz < cost) return;

        gameMasterScript.danScript.RWeights += 5;
        GameMaster.gainz -= cost;
        cost = (int) (cost * 1.7f);
    }

}
