using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static Vector3 MovementInput { get; private set; }
    public static bool IsMooving { get; private set; }
    public static float WeaponSpeed { get; set; }


    CharacterController cc;
    ProtaStadistics ps;
    CompanionStadistics cs;
    float speed;
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        ps = transform.GetChild(1).GetComponent<ProtaStadistics>();
        cs = transform.GetChild(2).GetComponent<CompanionStadistics>();
        WeaponSpeed = 1;
    }

    private void Update()
    {
        MovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        IsMooving = false;


        if (transform.GetChild(1).gameObject.activeSelf) speed = ps.ProtaSpeed * WeaponSpeed;
        else if (transform.GetChild(2).gameObject.activeSelf) speed = cs.CompanionSpeed * WeaponSpeed;



        if (MovementInput.magnitude > 0)
        {
            cc.Move(MovementInput.normalized * speed * Time.deltaTime);
            IsMooving = true;
        }
    }
}

