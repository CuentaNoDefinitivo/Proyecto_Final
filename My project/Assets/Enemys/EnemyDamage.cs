using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] float damage = 10;

    float damageTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Prota")
        {
            other.transform.GetComponent<ProtaHp>().hp -= damage;
        }
        else if (other.transform.tag == "Companion")
        {
            other.transform.GetComponent<CompanionHp>().Hp -= damage;
        }
        damageTime = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Prota" && damageTime >= 1)
        {
            other.transform.GetComponent<ProtaHp>().hp -= damage;
            damageTime = 0;
            Debug.Log("-hp stay");
        }
        else if (other.transform.tag == "Companion" && damageTime >= 1)
        {
            other.transform.GetComponent<CompanionHp>().Hp -= damage;
            damageTime = 0;
        }
        damageTime += Time.deltaTime;
    }
}
