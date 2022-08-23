using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    GameObject Weapon1;
    GameObject Weapon2;

    private void Start()
    {
        Weapon1 = transform.GetChild(0).gameObject;
        Weapon2 = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Weapon1.activeSelf == false && Weapon2.activeSelf == false)
        {
            PlayerData.WeaponSpeed = 1;
        }
    }
}
