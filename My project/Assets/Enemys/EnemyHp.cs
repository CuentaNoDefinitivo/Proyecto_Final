using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]NormalNeutralMonsterStadistics enemyHp;
    public float Hp {get; set;}
    private void Start()
    {
        Hp = enemyHp.Hp;
    }
    private void Update()
    {
        if(Hp <= 0)
        {
            DestroyImmediate(gameObject);
        }
    }
}
