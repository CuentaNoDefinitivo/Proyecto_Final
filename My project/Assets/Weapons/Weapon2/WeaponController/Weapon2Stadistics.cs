using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2Stadistics : MonoBehaviour
{
    [SerializeField] float weapon1Speed = 0.85f;
    [SerializeField] float weapon1Damage = 1.5f;


    void Update()
    {
        PlayerData.WeaponSpeed = weapon1Speed;
        PlayerData.WeaponDamage = weapon1Damage;
    }
}
