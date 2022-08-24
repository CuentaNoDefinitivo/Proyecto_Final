using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal2Enemy : MonoBehaviour
{
    [SerializeField] float hp = 30;
    public float Hp { get { return hp; }  set { hp = value; } }
    void Update()
    {
        if (Hp <= 0)
        {
            DestroyImmediate(gameObject);
        }
    }
}
