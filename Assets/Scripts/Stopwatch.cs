using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    private float stopwatchTime;

    public TextMeshProUGUI stopwatchTimeText;

    private void Start()
    {
        stopwatchTime = 0;
    }

    private void Update()
    {
        stopwatchTimeText.text = "Time Elapsed Before ASCENSION : " + GetMinutes(stopwatchTime).ToString() + "m " +
            GetSeconds(stopwatchTime).ToString() + "s";
        stopwatchTime += Time.deltaTime;
    }

    int GetMinutes(float time)
    {
        return Mathf.FloorToInt(time / 60);
    }

    int GetSeconds(float time)
    {
        return Mathf.FloorToInt(time % 60);
    }

}
