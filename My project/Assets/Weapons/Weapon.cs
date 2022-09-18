using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponStadistics weaponStadistics;
    public WeaponStadistics GetWeaponStadistics()
    {
        return weaponStadistics;
    }


    //CrosshairTypeEvent
    public static event Action<bool> sniperCrosshair;
    protected void InvokeSetCrosshairType(bool state)
    {
        sniperCrosshair?.Invoke(state);
    }
}