using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    static float hp = 10;
    public static float Hp { get { return hp; } set { hp = value; } }
    public static void RestarHp(float daño)
    {
        hp -= daño;
    }
    
    void Update()
    {
        if (Hp <= 0)
        {
            DestroyImmediate(gameObject);
        }
    }
}
