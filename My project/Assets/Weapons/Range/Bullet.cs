using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected RangeWeaponStadistics bulletStadistics;
    public CharacterStadistic CharacterStadistic { get; set; }
    private void Start()
    {
        DestroyBullet();
    }
    void Update()
    {
        Move();
    }
    protected void Move()
    {
        transform.Translate(Vector3.forward * bulletStadistics.BulletSpeed * Time.deltaTime);
    }
    void DestroyBullet()
    {
        Destroy(gameObject, bulletStadistics.BulletLifeTime);
    }
}