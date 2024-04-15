using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGMenuMaster : MonoBehaviour
{
    public Animator shopUI;
    public Animator optUI;

    private bool shopActive;
    private bool optActive;

    private void Start()
    {
        shopActive = false;
        optActive = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shopActive = !shopActive;
            optActive = !optActive;

            shopUI.SetBool("Active", shopActive);
            optUI.SetBool("Active", optActive);

            print(shopActive);
            print(optActive);
        }
    }
}
