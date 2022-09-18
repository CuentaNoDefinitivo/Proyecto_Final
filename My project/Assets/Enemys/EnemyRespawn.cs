using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesToRespawn;
    public uint enemyCount = 0;
    void Start()
    {
        StartCoroutine("A");
    }
    void RespawnEnemies()
    {
        foreach(GameObject enemy in enemiesToRespawn)
        {
            Instantiate(enemy,transform.position,transform.rotation).GetComponent<Enemies>().spawner = this.gameObject;
            enemyCount++;
        }
    }
    IEnumerator A()
    {
        if(enemyCount <= 3)
        {
            RespawnEnemies();
        }
        yield return new WaitForSeconds(10f);
        StartCoroutine("A");
    }
}
