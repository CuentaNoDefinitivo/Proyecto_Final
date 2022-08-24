using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public static Vector3 MousePosition { get; private set; }


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
            MousePosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(MousePosition);
        }
    }
}
