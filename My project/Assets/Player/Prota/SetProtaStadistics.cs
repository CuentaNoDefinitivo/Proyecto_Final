using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetProtaStadistics : SetCharacterStadistics
{
    Sprite Ability1Image;
    Sprite Ability2Image;

    Sprite MeleeImage;
    Sprite Weapon1Image;
    Sprite Weapon2Image;

    void Awake()
    {
        SetProperties();
    }
    private void OnEnable()
    {
        InstantiateHUD();
        SetStadisticsToPlayer();
        SetHUDImage();
    }
    private void OnDisable()
    {
        DestroyHUD();
    }
    protected override void SetHUDImage()
    {
        if(Ability1Image !=null ) hud.transform.Find("Ability1").GetComponent<Image>().sprite = Ability1Image;
        if (Ability2Image != null) hud.transform.Find("Ability2").GetComponent<Image>().sprite = Ability2Image;

        if (MeleeImage != null) hud.transform.Find("Melee").GetComponent<Image>().sprite = MeleeImage;
        if (Weapon1Image != null) hud.transform.Find("Melee").GetComponent<Image>().sprite = Weapon1Image;
        if (Weapon2Image != null) hud.transform.Find("Melee").GetComponent<Image>().sprite = Weapon2Image;
    }
}
