using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    LayerMask aimRaycast;
    private void Awake()
    {
        aimRaycast = LayerMask.GetMask("AimRaycast");
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(rayo,out hit,float.MaxValue,aimRaycast))
        {
            Vector3 mousePosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(mousePosition);
        }
        
    }
}
