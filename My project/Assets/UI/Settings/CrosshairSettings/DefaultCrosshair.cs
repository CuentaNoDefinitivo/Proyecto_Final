using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCrosshair : CrosshairColor
{
    public void SaveDefaultCrosshair()
    {
        SettingsManager.Instance.CrosshairColor = crosshairColor;
    }
}
