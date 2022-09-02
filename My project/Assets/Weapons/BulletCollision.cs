using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    [SerializeField] float weaponDamage;


    public float CharacterDamage { get; set; }
    /*public float CharacterDamage;
    public void Damage(float a)
    {
        CharacterDamage = a;
    }*/
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "NeutralMonster") 
        { 
            other.transform.parent.GetComponent<EnemyHp>().Hp -= weaponDamage + CharacterDamage;

            Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }
    private void Update()
    {
        
    }
}