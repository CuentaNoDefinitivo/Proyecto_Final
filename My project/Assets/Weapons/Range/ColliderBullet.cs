using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBullet : Bullet
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NeutralMonster")
        {
            other.GetComponent<Enemies>().Hp -= CharacterStadistic.Damage + bulletStadistics.Damage;
            Destroy(gameObject);
        }
        else Destroy(gameObject);
    }
}
