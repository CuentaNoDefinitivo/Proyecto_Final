using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] float enemyHp;
    public float Hp { get; set; }


    private void Start()
    {
        Hp = enemyHp;
    }
    void Update()
    {
        if(Hp <= 0)
        {
            DestroyImmediate(gameObject);
        }
    }
}