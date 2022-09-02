using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSlider : MonoBehaviour
{
    [SerializeField] ProtaHp protaHp;
    [SerializeField] CompanionHp companionHp;
    Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        if (protaHp.gameObject.activeSelf)
        {
            slider.maxValue = protaHp.MaxHp;
            slider.value = protaHp.Hp;
        }
        else
        {
            slider.maxValue = companionHp.MaxHp;
            slider.value = companionHp.Hp;
        }
    }
}
