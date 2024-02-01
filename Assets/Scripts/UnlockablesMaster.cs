using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockablesMaster : MonoBehaviour
{

    public GameObject[] items;
    private int currentObj;

    void Start()
    {
        currentObj = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        items[currentObj].SetActive(false);
        currentObj++;
        items[currentObj].SetActive(true);
    }
}
