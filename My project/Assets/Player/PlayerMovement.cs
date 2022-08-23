using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    Vector3 inputDirection = Vector3.zero;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        inputDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            inputDirection.z++;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            inputDirection.z--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputDirection.x++;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            inputDirection.x--;
        }
        
        cc.SimpleMove(inputDirection.normalized * PlayerData.Speed);

        //detectar si está moviendo
        if (inputDirection.magnitude != 0) 
            PlayerData.IsMooving = true;
        else
            PlayerData.IsMooving = false;
    }
}
