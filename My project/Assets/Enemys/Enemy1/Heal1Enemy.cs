using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal1Enemy : MonoBehaviour
{
    [SerializeField] float hp = 10;
    public float Hp { get { return hp; }  set { hp = value; } }
    void Update()
    {
        if (Hp <= 0)
        {
            DestroyImmediate(gameObject);
        }
    }
}
