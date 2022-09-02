using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    [SerializeField]Slider brightnessSlider;
    [SerializeField]Toggle fullScreenToggle;

    public void OnSaveButtonClick()
    {
        SettingsManager.Instance.Brightness = brightnessSlider.value;
        SettingsManager.Instance.FullScreen = fullScreenToggle.enabled;
    }
}
