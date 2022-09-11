using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadCrosshair : CrosshairColor
{
    public void SaveReloadCrosshairColor()
    {
        SettingsManager.Instance.ReloadCrosshairColor = crosshairColor;
    }
}
