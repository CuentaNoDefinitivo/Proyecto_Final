using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RangeWeapons : Weapon
{
        //Weapon Events
    //reload Event
    public static event Action Reloading;
    public static event Action<float, float> ReloadingCount;
    public static event Action StopReloading;
    //MunitionCount Event
    public static event Action<int,int> MunitionCount;


    //Stadistics Properties
    [SerializeField] GameObject bullet;
    CharacterStadistic characterStadistics;
    [SerializeField] protected RangeWeaponStadistics rangeWeaponStadistics;
    [SerializeField] AudioClip   shotAudio;


    //WeaponProperties
    protected int munitionCount;
    protected float reloadTimeCount;
    bool canShot = true;
    protected bool reloading = false;


    protected void GetCharacterDamage()
    {
        characterStadistics = GetComponentInParent<SetCharacterStadistics>().CharacterStadistic;
    }
    protected void Shot()
    {
        if (canShot && munitionCount > 0)
        {
            InstantiateBullet();//disparar
            munitionCount--;

            //tiempo entre disparo
            canShot = false;
            Invoke("CanShot", weaponStadistics.TimeBetweenAtacks);


            //stop reload and reset reload properties
            reloading = false;
            reloadTimeCount = 0;
            InvokeStopReloading();

            InvokeMunitionCount(munitionCount, rangeWeaponStadistics.Munition);

            //audio
            AudioSource.PlayClipAtPoint(shotAudio, transform.position);
        }
    }
    protected void InstantiateBullet()
    {
        var bulletInstance = Instantiate(bullet,transform.position,transform.rotation);
        bulletInstance.GetComponent<Bullet>().CharacterStadistic = characterStadistics;
    }
    void CanShot()
    {
        canShot = true;
    }


    protected void Reload()
    {
        if (reloading)
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
            if (munitionCount == rangeWeaponStadistics.Munition)
            {
                reloading = false;
                InvokeStopReloading();
                InvokeMunitionCount(munitionCount, rangeWeaponStadistics.Munition);
            }
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
