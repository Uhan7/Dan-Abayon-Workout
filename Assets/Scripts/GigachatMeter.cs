using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GigachatMeter : MonoBehaviour
{

    public TextMeshProUGUI percentText;

    public Image fillBarImage;

    private float fillVal;

    private void Update()
    {
        fillVal = (float)(GameMaster.gainz)/1000000000f;
        percentText.text = (Mathf.Round(fillVal * 1000.0f) * 0.1f).ToString() + "%";

        fillBarImage.fillAmount = fillVal;
    }

}
