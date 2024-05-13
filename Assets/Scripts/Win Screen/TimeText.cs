using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    private TextMeshProUGUI text;

    public GameObject stopwatch;
    private Stopwatch stopwatchScript;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        stopwatchScript = stopwatch.GetComponent<Stopwatch>();
    }

    void Update()
    {
        text.text = "Your time was:\n" + stopwatchScript.GetMinutes(stopwatchScript.stopwatchTime).ToString() + " mins and " +
            stopwatchScript.GetSeconds(stopwatchScript.stopwatchTime).ToString() + " secs";
    }
}
