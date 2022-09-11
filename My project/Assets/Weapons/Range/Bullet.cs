using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] WeaponStadistics bulletStadistics;
    public CharacterStadistic CharacterStadistic { get; set; }
    void Start()
    {
        Destroy();
    }
    void Update()
    {
        Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NeutralMonster")
        {
            Debug.Log("characterDamage " + CharacterStadistic.Damage + " weaponDamage " + bulletStadistics.Damage);
            other.GetComponent<Enemies>().Hp -= CharacterStadistic.Damage + bulletStadistics.Damage;
            Destroy(gameObject);
        }
        else Destroy(gameObject);
        Debug.Log(other.name);
    }
    protected void Move()
    {
        transform.Translate(Vector3.forward * bulletStadistics.BulletSpeed * Time.deltaTime);
    }
    protected void Destroy()
    {
        Destroy(gameObject, bulletStadistics.BulletLifeTime);
    }
}