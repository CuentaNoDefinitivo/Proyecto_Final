using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAdcCharacterStadistics : SetCharacterStadistics
{
    public void SetWeapon1Image(Sprite weapon1Image)
    {
        characterHudReference.transform.Find("Weapon1").GetComponent<Image>().sprite = weapon1Image;
    }
    public void SetWeapon2Image(Sprite weapon2Image)
    {
        characterHudReference.transform.Find("Weapon2").GetComponent<Image>().sprite = weapon2Image;
    }
}
