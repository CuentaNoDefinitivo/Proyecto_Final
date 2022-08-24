using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage1Enemy : MonoBehaviour
{

    [SerializeField] float damage = 100;

    float damageTime;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ha colisionado");//por alguna razón no me detecta las colisiones
        if(collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PlayerData>().Hp -= damage;
            Debug.Log("a");
        }
        damageTime = 0;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player" && damageTime >= 1)
        {
            collision.transform.GetComponent<PlayerData>().Hp -= damage;
            damageTime = 0;
        }
        damageTime += Time.deltaTime;
    }
}
