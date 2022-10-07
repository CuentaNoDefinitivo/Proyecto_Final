using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NewWeaponStadistics", menuName = "Weapons/NewWeaponStadistics")]
public class WeaponStadistics : ScriptableObject
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float timeBetweenAtacks = 0.7f;

    public float Speed { get => speed;}
    public float Damage { get => damage;}
    public float TimeBetweenAtacks { get => timeBetweenAtacks; set => timeBetweenAtacks = value; }
}
