using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{
    Image brightnessPanel;
    void Start()
    {
        brightnessPanel = GetComponent<Image>();
        brightnessPanel.color = new Color(brightnessPanel.color.r,brightnessPanel.color.g,brightnessPanel.color.b,1-SettingsManager.Instance.Brightness);
    }
    void Update()
    {
        if(brightnessPanel.color.a != SettingsManager.Instance.Brightness) 
            brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, 1 - SettingsManager.Instance.Brightness);
    }
}
