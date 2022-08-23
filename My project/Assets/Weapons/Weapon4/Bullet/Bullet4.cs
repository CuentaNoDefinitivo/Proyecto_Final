using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet4 : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float destroyTime = 5;

    private void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
