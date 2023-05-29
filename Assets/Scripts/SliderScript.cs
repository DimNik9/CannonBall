using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] TMP_Text sliderValue;
    [SerializeField] Slider slider;

    private void Start()
    {
        sliderValue.text = slider.value.ToString() + "°";
    }

    public void OnSliderValueChanged()
    {
        sliderValue.text = System.Math.Round(-slider.value,2).ToString() + "°";
    }

    public void OnLevelSliderValueChanged()
    {
        sliderValue.text = slider.value.ToString();
    }
}
