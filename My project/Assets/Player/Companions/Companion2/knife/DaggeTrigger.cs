using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggeTrigger : MonoBehaviour
{
    [SerializeField] float daggerDamage = 4.5f;


    public float CharacterDamage { get; set; }
    /*public void Damage(float a)
    {
        CharacterDamage = a;
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "NeutralMonster")
        {
            other.transform.parent.GetComponent<EnemyHp>().Hp -= daggerDamage + CharacterDamage;
        }
    }
    private void Update()
    {
        Debug.Log(CharacterDamage);
    }
}
