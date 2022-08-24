using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilitiesCompanion2 : MonoBehaviour
{
    [SerializeField] GameObject knife;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))  Habilities1(); 
    }

    void Habilities1()
    {
        Instantiate(knife,transform.position + new Vector3(0,1,0), transform.rotation);
    }
}
