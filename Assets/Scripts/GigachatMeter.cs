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
        fillVal = Mathf.Round((((float)(GameMaster.gainz) / 1000000000f) * 10.0f) * 0.1f);
        percentText.text = fillVal.ToString() + "%";

        fillBarImage.fillAmount = fillVal;
    }

}
