using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    private void Start()
    {
        PlayerAbilityManager.SetAbilityImage += SetAbilityImage;
    }
    void SetAbilityImage(int abilityIndex, Sprite abilitySprite)
    {
        if(abilityIndex == 1 && gameObject.CompareTag("Ability1"))
        {
            Image image = GetComponent<Image>();

            image.sprite = abilitySprite;
            image.color = Color.white;
        }
        else if(abilityIndex == 2 && gameObject.CompareTag("Ability2"))
        {
            Image image = GetComponent<Image>();

            image.sprite = abilitySprite;
            image.color = Color.white;
        }
    }
    private void OnDestroy()
    {
        PlayerAbilityManager.SetAbilityImage -= SetAbilityImage;
    }
}
