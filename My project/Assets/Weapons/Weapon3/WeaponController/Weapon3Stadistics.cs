using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon3Stadistics : MonoBehaviour
{
    [SerializeField] float weapon3Speed = 0.85f;
    [SerializeField] float weapon3Damage = 2f;


    void Update()
    {
        PlayerData.WeaponSpeed = weapon3Speed;
        PlayerData.WeaponDamage = weapon3Damage;
    }
}
