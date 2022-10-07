using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Image hpBar;
    private void Awake()
    {
        SetCharacterStadistics.HpChanged += SetHpBar;
        hpBar = GetComponent<Image>();
    }
    void SetHpBar(float hpCount, float maxHp)
    {
        hpBar.fillAmount = hpCount / maxHp;
    }
    private void OnDisable()
    {
        SetCharacterStadistics.HpChanged -= SetHpBar;
    }
}
