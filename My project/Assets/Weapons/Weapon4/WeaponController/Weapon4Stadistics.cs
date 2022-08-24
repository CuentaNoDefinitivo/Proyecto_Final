using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon4Stadistics : MonoBehaviour
{
    [SerializeField] float weapon4Speed = 0.85f;
    [SerializeField] float weapon4Damage = 2;


    void Update()
    {
        PlayerData.WeaponSpeed = weapon4Speed;
        PlayerData.WeaponDamage = weapon4Damage;
    }
}
