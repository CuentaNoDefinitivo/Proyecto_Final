using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLowHpVignette : MonoBehaviour
{
    private void Start()
    {
        SetCharacterStadistics.HpChanged += EnableVignette;
    }
    void EnableVignette(float hp, float maxHp)
    {
        if (hp < (maxHp/2)) transform.GetChild(0).gameObject.SetActive(true);
    }
    void OnDestroy()
    {
        SetCharacterStadistics.HpChanged -= EnableVignette;
    }
}
