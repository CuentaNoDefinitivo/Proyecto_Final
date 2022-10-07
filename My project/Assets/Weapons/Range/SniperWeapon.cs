using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperWeapon : RangeWeapons
{
    
    private void Start()
    {
        munitionCount = rangeWeaponStadistics.Munition;
        GetCharacterDamage();
        InvokeMunitionCount(munitionCount, rangeWeaponStadistics.Munition);

        InvokeSetCrosshairType(true);
    }
    private void Update()
    {
        //disparar
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shot();
        }

        //Reload.
        if (Input.GetKey(KeyCode.R) && munitionCount < rangeWeaponStadistics.Munition)   reloading = true;
        Reload();
        
    }
    private void OnEnable()
    {
        InvokeStopReloading();
        InvokeSetCrosshairType(true);
        InvokeMunitionCount(munitionCount, rangeWeaponStadistics.Munition);
    }
    void OnDisable() 
    {
        //Reset reload properties 
        reloadTimeCount = 0;
        reloading = false;

        //Reset CrosshairEvents
        InvokeStopReloading();

        InvokeMunitionCount(0, 0);
    }
}
