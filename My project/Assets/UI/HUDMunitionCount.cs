using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDMunitionCount : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;
    private void Start()
    {
        RangeWeapons.MunitionCount += SetMunitionCountText;
        RangeWeapons.ReloadingCount += SetMunitionCountText;
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    void SetMunitionCountText(int munitionCount,int munition)
    {
        textMeshPro.text = munitionCount + " / " + munition;
    }
    void SetMunitionCountText(float reloadCount, float reloadTime)
    {
        textMeshPro.text = reloadCount + " / " + reloadTime;
    }
}