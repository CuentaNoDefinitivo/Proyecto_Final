using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1Stadistics : MonoBehaviour
{
    [SerializeField] float weapon1Speed = 0.5f;
    [SerializeField] float weapon1Damage = 1;

    
    void Update()
    {
        PlayerData.WeaponSpeed = weapon1Speed;
        PlayerData.WeaponDamage = weapon1Damage;
    }
}
