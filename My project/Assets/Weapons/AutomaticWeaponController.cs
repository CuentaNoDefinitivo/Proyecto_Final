using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutomaticWeaponController : MonoBehaviour
{
    [SerializeField] float timeBetweenShot = 0.1f;
    [SerializeField] GameObject bullet;
    [SerializeField] int munitions;
    [SerializeField] float reloadTime;
    [SerializeField] float randomBullet;

    int munitionCount;
    float reloadTimeCount;
    TextMeshProUGUI munitionText;
    bool reloading = false;
    bool canShoot = true;

    private void Start()
    {
        munitionCount = munitions;
        munitionText = FindObjectOfType<Canvas>().transform.Find("MunitionText").GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        //Shot
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot && munitionCount > 0 && !reloading)
        {
            InstantiateBullet();
            canShoot = false;
            Invoke("CanShoot", timeBetweenShot);
            munitionCount--;
        }
        else if (Input.GetKey(KeyCode.Mouse0) && canShoot && munitionCount > 0 && !reloading)
        {
            InstantiateBullet();
            canShoot = false;
            Invoke("CanShoot", timeBetweenShot);
            munitionCount--;
        }
        //reload
        else if (Input.GetKeyUp(KeyCode.R) && !reloading && munitionCount != munitions)
        {
            reloading = true;
            reloadTimeCount = 0;
        }
        if (reloading)
        {
            reloadTimeCount += Time.deltaTime;
            if (reloadTimeCount >= reloadTime) Reload();
        }
        //MunitionText
        munitionText.text = munitionCount.ToString() + " / " + munitions.ToString();
    }
    void InstantiateBullet()
    {
        var bulletInstant = Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0,Random.Range(-randomBullet, randomBullet),0));

        if (transform.parent.parent.CompareTag("Prota"))
            bulletInstant.GetComponent<BulletCollision>().CharacterDamage = transform.parent.parent.GetComponent<ProtaStadistics>().ProtaDamage;
        else
            bulletInstant.GetComponent<BulletCollision>().CharacterDamage = transform.parent.parent.GetComponent<CompanionStadistics>().CompanionDamage;


    }
    void CanShoot()
    {
        canShoot = true;
    }
    void Reload()
    {
        munitionCount = munitions;
        reloading = false;
    }
}
