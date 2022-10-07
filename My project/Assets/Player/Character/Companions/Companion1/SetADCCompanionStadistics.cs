using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetADCCompanionStadistics : SetCharacterStadistics
{
    [SerializeField] Sprite pasiveImage;
    [SerializeField] Sprite ability1Image;
    [SerializeField] Sprite ability2Image;

    [SerializeField] Sprite meleeImage;
    [SerializeField] Sprite weapon1Image;
    [SerializeField] Sprite weapon2Image;
    private void Awake()
    {
        SetProperties();
    }
    private void OnEnable()
    {
        InstantiateHUD();
        SetHUDImage();
        SetStadisticsToPlayer();
    }
    private void OnDisable()
    {
        DestroyHUD();
    }
    protected override void SetHUDImage()
    {
        characterHudReference.transform.Find("Pasive").GetComponent<Image>().sprite = pasiveImage;
        characterHudReference.transform.Find("Ability1").GetComponent<Image>().sprite = ability1Image;
        characterHudReference.transform.Find("Ability2").GetComponent<Image>().sprite = ability2Image;

        characterHudReference.transform.Find("Melee").GetComponent<Image>().sprite = meleeImage;
        characterHudReference.transform.Find("Weapon1").GetComponent<Image>().sprite = weapon1Image;
        characterHudReference.transform.Find("Weapon2").GetComponent<Image>().sprite = weapon2Image;
    }
}
