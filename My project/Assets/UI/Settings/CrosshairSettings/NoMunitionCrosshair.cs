using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMunitionCrosshair : CrosshairColor
{
    public void SaveNoMunitionCrosshairColor()
    {
        SettingsManager.Instance.NoMunitionCrosshairColor = crosshairColor;
    }
}
