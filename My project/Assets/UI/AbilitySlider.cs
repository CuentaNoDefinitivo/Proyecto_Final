using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlider : MonoBehaviour
{
    Slider abiliticooldownSlider;
    private void Start()
    {
        abiliticooldownSlider = GetComponent<Slider>();
    }
    void Update()
    {
        if (abiliticooldownSlider.value > 0)
        {
            abiliticooldownSlider.value -= Time.deltaTime;
        }
    }
    public void StartCooldownCount()
    {
        abiliticooldownSlider.value = abiliticooldownSlider.maxValue;
    }
}
