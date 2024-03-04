using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GigachadButton : MonoBehaviour
{

    private Button selfButton;

    private void Awake()
    {
        selfButton = GetComponent<Button>();
    }

    void Start()
    {
        selfButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMaster.gainz >= 10000000000f) selfButton.interactable = true;
    }
}
