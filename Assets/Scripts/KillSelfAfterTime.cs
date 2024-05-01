using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelfAfterTime : MonoBehaviour
{
    public float killSelfTime;
    void Start()
    {
        Destroy(gameObject, killSelfTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
