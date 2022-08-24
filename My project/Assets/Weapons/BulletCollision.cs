using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "NeutralMonster")
        {
            other.transform.parent.GetComponent<Heal1Enemy>().Hp -= PlayerData.Damage;

            Destroy(gameObject);
        }
        else if(other.transform.tag == "NeutralMonster2")
        {
            other.transform.parent.GetComponent<Heal2Enemy>().Hp -= PlayerData.Damage;

            Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }

    
}
