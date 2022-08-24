using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    [SerializeField] float force = 5;
    private Rigidbody rigidbody;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rigidbody.AddForce(Vector3.forward * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
