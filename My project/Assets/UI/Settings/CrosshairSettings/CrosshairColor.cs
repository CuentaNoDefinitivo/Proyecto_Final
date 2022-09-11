using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairColor : MonoBehaviour
{
    [SerializeField] Image crosshair;
    [SerializeField] Slider hue;
    [SerializeField] Slider saturation;
    [SerializeField] Slider value;

    protected Color crosshairColor;

    void Update()
    {
        crosshairColor = Color.HSVToRGB(hue.value, saturation.value, value.value);
        crosshair.color = crosshairColor;
    }
}
