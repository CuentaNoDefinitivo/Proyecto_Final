using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Destroyable":
                //other.GetComponentInParent<Heal>().RestarHp(PlayerData.Damage);
                Destroy(gameObject);
                break;

            case "Undestroyable":
                Destroy(gameObject);
                break;
        }
    }
}
