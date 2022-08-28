using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStadistics : MonoBehaviour
{
    [SerializeField] float weaponSpeed = 0.5f;


    void Update()
    {
        PlayerMovement.WeaponSpeed = weaponSpeed;
    }
}
