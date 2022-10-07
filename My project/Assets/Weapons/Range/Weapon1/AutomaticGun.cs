using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticGun : RangeWeapons
{
    void Start()
    {
        munitionCount = rangeWeaponStadistics.Munition;
        GetCharacterDamage();
        InvokeMunitionCount(munitionCount, rangeWeaponStadistics.Munition);

        InvokeSetCrosshairType(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shot();
        }
        if (Input.GetKey(KeyCode.R) && munitionCount < rangeWeaponStadistics.Munition) reloading = true;
        Reload();
    }
    private void OnEnable()
    {
        InvokeStopReloading();
        InvokeSetCrosshairType(true);
        InvokeMunitionCount(munitionCount, rangeWeaponStadistics.Munition);
    }
    private void OnDisable()
    {
        //Reset reload properties 
        reloadTimeCount = 0;
        reloading = false;

        //Reset CrosshairEvents
        InvokeStopReloading();

        InvokeMunitionCount(0, 0);
    }
}
