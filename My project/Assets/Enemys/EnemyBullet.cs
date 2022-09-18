using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] NormalNeutralMonsterStadistics bulletStadistics;
    [SerializeField] float speed = 20;
    [SerializeField] float destroyTime = 4;

    private void Start()
    {
        BulletDestroy();
    }
    void Update()
    {
        BulletMovement();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Prota" || other.tag == "Companion")
        {
            other.GetComponent<SetCharacterStadistics>().ReceiveDamage(bulletStadistics.Damage);
            Destroy(gameObject);
        }
        else if(other.tag != "NeutralMonster") Destroy(gameObject);
    }
    protected virtual void BulletMovement()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    protected virtual void BulletDestroy()
    {
        Destroy(gameObject,destroyTime);
    }
}
