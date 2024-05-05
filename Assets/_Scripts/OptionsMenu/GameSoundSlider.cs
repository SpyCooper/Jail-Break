using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameSoundSlider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private Slider slider;

    private float sliderValue;

    private void Start()
    {
        sliderValue = GameManager.Instance.GetGameSoundVolume();
        valueText.text = ((int)sliderValue).ToString();
        slider.value = sliderValue;
    }

    public void OnSliderChanged(float value)
    {
        valueText.text = sliderValue.ToString();
        sliderValue = value;
    }
}
