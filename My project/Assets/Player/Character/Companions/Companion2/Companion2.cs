using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Companion2 : Companion
{
    [SerializeField] GameObject knife;
    [SerializeField] float hability1Cooldown = 1f;
    [SerializeField] float hability2Cooldown = 5;

    float hability1CooldownCount = 1f;
    float hability2CooldownCount = 5;

    public static event Action Companion2Hability2;
    void Update()
    {
        if (hability1CooldownCount < hability1Cooldown) hability1CooldownCount += Time.deltaTime;
        if (hability2CooldownCount < hability2Cooldown) hability2CooldownCount += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha1) && hability1CooldownCount >= hability1Cooldown)
        {
            Ability1();
            hability1CooldownCount = 0;
        }

        if (Input.GetKey(KeyCode.Alpha2) && hability2CooldownCount >= hability2Cooldown)
        {
            Companion2Hability2?.Invoke();
            hability2CooldownCount = 0;
        }
    }
    void Ability1()
    {
        var knifeInstance = Instantiate(knife,transform.position, transform.rotation);
        knifeInstance.GetComponent<KnifeMovement>().companion2Reference = transform;
    }
}
