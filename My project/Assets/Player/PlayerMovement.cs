using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float gravedad;
    public bool canMove { get; set; }
    public static Vector3 MovementInput { get; private set; }
    public static bool IsMooving { get; private set; }
    public static float WeaponSpeed { get; set; }


    CharacterController cc;
    ProtaStadistics ps;
    CompanionStadistics cs;
    float speed;
    private void Awake()
    {
        canMove = true;
        cc = GetComponent<CharacterController>();
        ps = transform.GetChild(1).GetComponent<ProtaStadistics>();
        cs = transform.GetChild(3).GetComponent<CompanionStadistics>();
        WeaponSpeed = 1;
    }

    private void Update()
    {
        MovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        IsMooving = false;


        if (transform.GetChild(1).gameObject.activeSelf) speed = ps.ProtaSpeed * WeaponSpeed;
        else if (transform.GetChild(3).gameObject.activeSelf) speed = cs.CompanionSpeed * WeaponSpeed;



        if (MovementInput.magnitude > 0 && canMove)
        {
            cc.Move(MovementInput.normalized * speed * Time.deltaTime);
            IsMooving = true;
        }
        if (transform.position.y > 1)
        {
            cc.SimpleMove(Vector3.down * gravedad);
            Debug.Log("cayendo");
        }
    }
}

