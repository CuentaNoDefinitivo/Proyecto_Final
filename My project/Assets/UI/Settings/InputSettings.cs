using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSettings : MonoBehaviour
{
    [SerializeField] Slider brightnessSlider;
    [SerializeField] Image brightnessPanel;
    [SerializeField] Toggle fullScreenToggle;

    private void Start()
    {
        brightnessSlider.value = SettingsManager.Instance.Brightness;
        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, 1 - SettingsManager.Instance.Brightness);

        //fullScreen
        if (Screen.fullScreen) { fullScreenToggle.isOn = true; Debug.Log("fullScreen"); }
        else { fullScreenToggle.isOn = false; }
    
    }
    void Update()
    {
        //brightness
        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, 1 - brightnessSlider.value);

        //fullScreen
        if (fullScreenToggle.isOn)
        {
            Screen.fullScreen = true;
        }
        else Screen.fullScreen = false;
    }
    public void SaveButton()
    {
        SettingsManager.Instance.Brightness = brightnessSlider.value;
        SettingsManager.Instance.FullScreen = fullScreenToggle.isOn;
    }
}
