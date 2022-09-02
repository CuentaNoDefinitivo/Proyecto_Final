using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Vector3 MousePosition { get; private set; }
    public bool CanRotate { get; set; }

    LayerMask aimRaycast;
    private void Awake()
    {
        CanRotate = true;
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
            if(CanRotate) transform.LookAt(MousePosition);
        }
    }
}
