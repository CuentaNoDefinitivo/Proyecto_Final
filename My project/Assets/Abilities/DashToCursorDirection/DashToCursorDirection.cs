using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashToCursorDirection : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] float cooldown = 5;
    float cooldonwCount = 5;
    bool dashing = false;
    Vector3 dashingPosition;
    Quaternion dashRotation;
    Quaternion dashingRotation;
    PlayerRotation playerRotation;
    PlayerMovement playerMovement;

    private void Start()
    {
        playerRotation = transform.parent.parent.GetComponent<PlayerRotation>();
        playerMovement = transform.parent.parent.GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        if (cooldonwCount < cooldown) cooldonwCount += Time.deltaTime;


        else if (Input.GetKeyDown(KeyCode.Alpha2) && cooldonwCount >= cooldown)
        {
            dashing = true;
            Invoke("StopDashing", 1f);
            cooldonwCount = 0;
            dashingPosition = playerRotation.MousePosition;
            dashRotation = Quaternion.LookRotation(dashingPosition,Vector3.up);
            transform.parent.parent.rotation = dashRotation;
            playerRotation.CanRotate = false;
            playerMovement.canMove = false;
            
        }
    
        if (dashing)
        {
            Dashing(dashingPosition);
        }
        //Debug.Log(dashingRotation + " " + dashRotation);
        
    }
    void Dashing(Vector3 direction)
    {
        dashingRotation = Quaternion.LookRotation(dashingPosition, Vector3.up);
        transform.parent.parent.Translate(Vector3.forward * speed * Time.deltaTime);
        if (dashingRotation != dashRotation) dashing = false;
    }
    void StopDashing()
    {
        dashing = false;
        playerRotation.CanRotate = true;
        playerMovement.canMove = true;
    }
}
