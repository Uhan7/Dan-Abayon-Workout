using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockablesMaster : MonoBehaviour
{

    public GameObject[] items;
    public GameObject[] equips;

    private int currentObj;
    private int currentEquip;

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
