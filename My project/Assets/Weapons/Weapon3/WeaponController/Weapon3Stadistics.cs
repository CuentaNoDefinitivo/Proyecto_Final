using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon3Stadistics : MonoBehaviour
{
    [SerializeField] float weapon1Speed = 0.85f;


    void Update()
    {
        PlayerData.WeaponSpeed = weapon1Speed;
    }
}
