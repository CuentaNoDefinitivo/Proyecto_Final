using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerToFollowAndLook;
    [SerializeField] Vector3 ofset;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerToFollowAndLook.position + ofset;
        transform.LookAt(playerToFollowAndLook);
    }
}
