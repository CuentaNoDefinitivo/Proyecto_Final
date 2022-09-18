using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDLookCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(68.199f, 0, 0);
    }
}
