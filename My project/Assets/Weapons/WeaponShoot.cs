using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] float timeBetweenShot = 0.86f;
    [SerializeField] GameObject bullet;
    [SerializeField] BulletCollision bulletCollision;
    bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            InstantiateBullet();
            canShoot = false;
            Invoke("CanShoot",timeBetweenShot);
        }
    }
    void InstantiateBullet()
    {
        if (transform.parent.parent.CompareTag("Prota"))
            bulletCollision.Damage(transform.parent.parent.GetComponent<ProtaStadistics>().ProtaDamage);
            //bulletCollision.CharacterDamage = transform.parent.parent.GetComponent<ProtaStadistics>().ProtaDamage;
        else
            bulletCollision.Damage(transform.parent.parent.GetComponent<CompanionStadistics>().CompanionDamage);

        Instantiate(bullet, transform.position, transform.rotation);
    }
    void CanShoot()
    {
        canShoot = true;
    }
    
}
