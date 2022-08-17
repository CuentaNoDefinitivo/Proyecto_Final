using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static float CharacterSpeed { get; set; }
    public static float WeaponSpeed { get; set; }
    private static float speed;
    public static float Speed { get { return speed; } }
    private void Update()
    {
        speed = CharacterSpeed * WeaponSpeed;
    }
}
    