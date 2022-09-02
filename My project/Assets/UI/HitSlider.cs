using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitSlider : MonoBehaviour
{
    Slider healSlider;
    Slider slider;
    float currentValue;
    float healValue;
    bool invoked = false;

    void Start()
    {
        healSlider = transform.parent.GetComponent<Slider>();
        slider = GetComponent<Slider>();
        slider.maxValue = healSlider.maxValue;
        currentValue = healSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = healSlider.maxValue;
        healValue = healSlider.value;
        if (healValue < currentValue)
        {
            LerpToHealValue();
            if (!invoked) 
            { 
                Invoke("CurrentValueToHealValue", 6f); 
                invoked = true; 
            }
        }
        else {
            currentValue = healValue;
            slider.value = currentValue;
        }
    }
    void LerpToHealValue()
    {
        currentValue = Mathf.Lerp(currentValue, healValue, 0.01f);
        slider.value = currentValue;
    }
    void CurrentValueToHealValue()
    {
        currentValue = healValue;
        invoked = false;
    }
}
