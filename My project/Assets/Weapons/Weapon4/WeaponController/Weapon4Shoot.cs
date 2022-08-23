using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon4Shoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            canShoot = false;
            Invoke("CanShoot",1f);
        }
    }
    void CanShoot()
    {
        canShoot = true;
    }
}
