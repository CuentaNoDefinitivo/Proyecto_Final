using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessSettings : MonoBehaviour
{
    [SerializeField] Slider brightnessSlider;
    [SerializeField] Image brightnessPanel;
    void Start()
    {
        brightnessSlider.value = SettingsManager.Instance.Brightness;
        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, 1 - SettingsManager.Instance.Brightness);

    }

    // Update is called once per frame
    void Update()
    {
        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, 1 - brightnessSlider.value);
    }

    public void SaveBrightness()
    {
        SettingsManager.Instance.Brightness = brightnessSlider.value;
    }
}
