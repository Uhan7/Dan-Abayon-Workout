using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    public Slider slider;

    public bool SFXSlider;
    public bool BGMSlider;

    public AudioSource SFXSource;
    public AudioSource BGMSource;

    private void Update()
    {
        if (SFXSlider) SFXSource.volume = slider.value;
        if (BGMSlider) BGMSource.volume = slider.value;
    }

}
