using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsUI : MonoBehaviour
{
    [SerializeField] Sprite weaponSprite;

    Image weaponImage;
    void Start()
    {
        if (transform.GetSiblingIndex() == 0) weaponImage = FindObjectOfType<Canvas>().transform.Find("WeaponsPanel").GetChild(0).GetComponent<Image>();
        else weaponImage = FindObjectOfType<Canvas>().transform.Find("WeaponsPanel").GetChild(1).GetComponent<Image>();

        weaponImage.sprite = weaponSprite;
        weaponImage.color = Color.white;
    }
}
