using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitSlider : MonoBehaviour
{
    [SerializeField]Image HpBar;
    [SerializeField]Image HitBar;

    void Update()
    {
        if (HpBar.fillAmount < HitBar.fillAmount)
        {
            HitBar.fillAmount = Mathf.Lerp(HitBar.fillAmount, HpBar.fillAmount, 1f * Time.deltaTime);
        }
        if (HpBar.fillAmount >= HitBar.fillAmount || Mathf.Round(HpBar.fillAmount * 100) == Mathf.Round(HitBar.fillAmount * 100))
        {
            HitBar.fillAmount = HpBar.fillAmount;
        }
    }
}
