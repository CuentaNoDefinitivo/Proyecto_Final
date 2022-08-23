using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    [SerializeField] float speed = 4f;


    Vector3 preyPosition;
    public static bool PreyInRange { get; private set; }
    Quaternion angleToRotate;

    void Update()
    {
        if (PreyInRange)
        {
            angleToRotate = Quaternion.LookRotation(preyPosition - new Vector3(transform.position.x, 0, transform.position.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, angleToRotate, 0.01f);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        { 
            preyPosition = new Vector3(other.transform.position.x, 0, other.transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") PreyInRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") PreyInRange = false;
    }
}
