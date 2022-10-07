using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerAbilityManager : MonoBehaviour
{
    [SerializeField] GameObject ability1;
    [SerializeField] GameObject ability2;

    bool haveAbility1;
    bool haveAbility2;

    string ability1Name;
    string ability2Name;

    public static event Action<int, Sprite> SetAbilityImage;
    void HaveAbility1()
    {
        if (ability1.transform.childCount == 1) haveAbility1 = true;
        else haveAbility1 = false;
    }
    void HaveAbility2()
    {
        if (ability2.transform.childCount == 1) haveAbility2 = true;
        else haveAbility2 = false;
    }
    public bool EquipAbilities(GameObject ability, Sprite abilitySprite, string abilityName)
    {
        HaveAbility1();
        HaveAbility2();
        if (ability1Name != abilityName && ability2Name != abilityName)
        {
            if (!haveAbility1)
            {
                EquipAbility1(ability, abilitySprite, abilityName);
                return true;
            }
            else if (!haveAbility2)
            {
                EquipAbility2(ability, abilitySprite, abilityName);
                return true;
            }
            else return false;
        }
        else
            return false;
    }
    void EquipAbility1(GameObject ability, Sprite abilitySprite, string abilityName)
    {
        Instantiate(ability, ability1.transform);
        haveAbility1 = true;
        ability1Name = abilityName;
        SetAbilityImage?.Invoke(1, abilitySprite);
        GetComponentInParent<SetCharacterStadistics>().InstanceCharacterHUD.transform.Find("Ability1").GetComponent<Image>().sprite = abilitySprite;
    }
    void EquipAbility2(GameObject ability, Sprite abilitySprite, string abilityName)
    {
        Instantiate(ability, ability2.transform);
        haveAbility2 = true;
        ability2Name = abilityName;
        SetAbilityImage?.Invoke(2, abilitySprite);
        GetComponentInParent<SetCharacterStadistics>().InstanceCharacterHUD.transform.Find("Ability2").GetComponent<Image>().sprite = abilitySprite;
    }
}