using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperWeapon : RangeWeapons
{
    bool canShot = true;
    bool reloading = false;
    
    private void Start()
    {
        munitionCount = rangeWeaponStadistics.Munition;
        GetCharacterDamage();
        InvokeMunitionCount(munitionCount, rangeWeaponStadistics.Munition);
    }
    private void Update()
    {
        //disparar
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShot && munitionCount > 0)
        {
            Shot();//disparar

            //tiempo entre disparo
            canShot = false;
            Invoke("CanShot", 0.7f);

            //stop reload and reset reload properties
            reloading = false;
            reloadTimeCount = 0;
            InvokeStopReloading();

            InvokeMunitionCount(munitionCount,rangeWeaponStadistics.Munition);
        }

        //Reload.
        if (Input.GetKey(KeyCode.R) && munitionCount < rangeWeaponStadistics.Munition)   reloading = true;
        if (reloading)
        {
            Reload();
            if (munitionCount == rangeWeaponStadistics.Munition) 
            { 
                reloading = false;
                InvokeStopReloading();
                InvokeMunitionCount(munitionCount, rangeWeaponStadistics.Munition);
            }
        }
        //NoMunition
        
    }
    private void OnEnable()
    {
        SetWeaponsStadistics();

        InvokeStopReloading();
        InvokeMunitionCount(munitionCount, rangeWeaponStadistics.Munition);
    }
    void OnDisable() 
    {
        //Reset reload properties 
        reloadTimeCount = 0;
        reloading = false;

        //Reset CrosshairEvents
        InvokeStopReloading();
    }
    void CanShot()
    {
        canShot = true;
    }
}
