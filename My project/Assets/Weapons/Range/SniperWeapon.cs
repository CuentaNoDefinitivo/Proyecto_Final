using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperWeapon : RangeWeapons
{
    bool canShot = true;
    bool reloading = false;
    float reloadTimeCount;
    private void Start()
    {
        munitionCount = rangeWeaponStadistics.Munition;
        GetCharacterDamage();
    }
    private void Update()
    {
        //disparar
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShot && munitionCount > 0)
        {
            Shot();

            //tiempo entre disparo
            canShot = false;
            Invoke("CanShot", 0.75f);

            //stop reload
            reloading = false;
        }
        //Reload.
        else if (Input.GetKey(KeyCode.R))
        {
            reloading = true;
        }
        if (reloading)
        {
            reloadTimeCount += Time.deltaTime;
            if(reloadTimeCount >= rangeWeaponStadistics.ReloadTime)
            {
                munitionCount = rangeWeaponStadistics.Munition;
                reloadTimeCount = 0;
                reloading = false;
            }
        }
    }
    void CanShot()
    {
        canShot = true;
    }
}
