using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RangeWeapons : Weapon
{
    [SerializeField] protected RangeWeaponStadistics rangeWeaponStadistics;

    //Weapon Events
    public static event Action Reloading;
    public static event Action<float, float> ReloadingCount;
    public static event Action StopReloading;

    public static event Action<int,int> MunitionCount;

    [SerializeField] GameObject bullet;
    CharacterStadistic characterStadistics;
    protected int munitionCount;
    protected float reloadTimeCount;
    protected void Shot()
    {
        var bulletInstance = Instantiate(bullet,transform.position,transform.rotation);
        bulletInstance.GetComponent<Bullet>().CharacterStadistic = characterStadistics;
        munitionCount--;
    }
    protected void GetCharacterDamage()
    {
        characterStadistics = GetComponentInParent<SetCharacterStadistics>().CharacterStadistic;
    }
    protected void Reload()
    {
        reloadTimeCount += Time.deltaTime;
        Reloading?.Invoke();
        ReloadingCount?.Invoke(Mathf.Round(reloadTimeCount * 10)/10, rangeWeaponStadistics.ReloadTime);
        if (reloadTimeCount >= rangeWeaponStadistics.ReloadTime)
        {
            munitionCount = rangeWeaponStadistics.Munition;
            InvokeMunitionCount(munitionCount, rangeWeaponStadistics.Munition);
            reloadTimeCount = 0;
        }
    }

    protected void InvokeMunitionCount(int munitionCount, int munition)
    {
        MunitionCount?.Invoke(munitionCount, munition);
    }

    protected void InvokeStopReloading()
    {
        StopReloading?.Invoke();
    }
}
