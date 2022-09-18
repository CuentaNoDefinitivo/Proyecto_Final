using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtackTrigger : MonoBehaviour
{
    [SerializeField] NormalNeutralMonsterStadistics enemy1Stadistics;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Prota" || other.tag == "Companion")
        {
            other.GetComponent<SetCharacterStadistics>().ReceiveDamage(enemy1Stadistics.Damage);
        }
    }
}
