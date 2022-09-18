using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AtackEvent : MonoBehaviour
{
    [SerializeField]GameObject bullet;
    public void InstantaiteBullet()
    {
        Instantiate(bullet, transform.position + Vector3.up,transform.rotation);
    }
}
