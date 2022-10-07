using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NewRangeWeaponStadistics", menuName = "Weapons/NewRangeWeaponStadistics")]
public class RangeWeaponStadistics : WeaponStadistics
{
    [SerializeField] int munition;
    [SerializeField] float reloadTime;
    [SerializeField] float bulletLifeTime;
    [SerializeField] float bulletSpeed;




    public int Munition { get => munition; }
    public float ReloadTime { get => reloadTime; }
    public float BulletLifeTime { get => bulletLifeTime; }
    public float BulletSpeed { get => bulletSpeed; }
}
