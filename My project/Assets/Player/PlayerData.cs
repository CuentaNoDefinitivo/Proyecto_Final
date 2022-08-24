using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    float hp = 40;
    public float Hp { get { return hp; } set { hp = value; } }
    public static bool IsMooving { get; set; }


    public static float CharacterDamage { get; set; }
    public static float WeaponDamage { get; set; }
    public static float Damage { get; private set; }


    public static float CharacterSpeed { get; set; }
    public static float WeaponSpeed { get; set; }
    public static float Speed { get; private set; }

    private void Update()
    {
        Speed = CharacterSpeed * WeaponSpeed;
        Damage = CharacterDamage + WeaponDamage;

        if (hp <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}
    