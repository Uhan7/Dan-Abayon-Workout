using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GainzText : MonoBehaviour
{
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = "Your total Gainz:\n" + GameMaster.gainz.ToString();
    }
}
