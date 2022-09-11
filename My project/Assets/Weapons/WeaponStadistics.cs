using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NewWeaponStadistics", menuName = "Weapons/NewWeaponStadistics")]
public class WeaponStadistics : ScriptableObject
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] int munition;
    [SerializeField] float reloadTime;
    [SerializeField] float bulletLifeTime;
    [SerializeField] float bulletSpeed;

    public float Speed { get => speed;}
    public float Damage { get => damage;}
    public int Munition { get => munition;}
    public float ReloadTime { get => reloadTime;}
    public float BulletLifeTime { get => bulletLifeTime;}
    public float BulletSpeed { get => bulletSpeed;}
}
