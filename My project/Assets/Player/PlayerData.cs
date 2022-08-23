using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static bool IsMooving { get; set; }


    public static float CharacterDamage { get; set; }
    public static float WeaponDamage { get; set; }
    private static float damage;
    public static float Damage { get { return damage; } }


    public static float CharacterSpeed { get; set; }
    public static float WeaponSpeed { get; set; }
    private static float speed;
    public static float Speed { get { return speed; } }
    private void Update()
    {
        speed = CharacterSpeed * WeaponSpeed;
        damage = CharacterDamage + WeaponDamage;
    }
}
    