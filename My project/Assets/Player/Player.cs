using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    //movement
    CharacterController cc;
    Vector3 MoveDirection;

    //rotation
    [SerializeField] LayerMask aimRaycast;
    Vector3 MousePosition;

    // characterRerefences and ChangeCharacter
    [SerializeField]GameObject prota;
    GameObject companion;
    bool canChange = true;

    //alive
    public bool protaAlive { get; set; }
    public bool companionAlive { get; set; }
    //CompanionScriptableObject
    public CharacterStadistic CharacterStadistics { get;  set; }
    public WeaponStadistics WeaponStadistics { get; set; }
    void Start()
    {
        cc = GetComponent<CharacterController>();
        //GetProtaAndCompanionReferences && desactive companion active prota
        companion = transform.GetChild(3).gameObject;
        protaAlive = true;
        companionAlive = true;

        prota.SetActive(true);
        companion.SetActive(false);
    }
    void Update()
    {
        if (protaAlive || companionAlive)
        {
            Rotate();
            Move();
        }

        if(Input.GetKeyDown(KeyCode.Tab) && canChange && protaAlive && companionAlive) ChangeCharacter(); // if tab && canChange then change.

        //deathAlive Manager
        if (protaAlive && !companionAlive) 
        {
            prota.SetActive(true); 
            companion.SetActive(false); 
        }
        if(!protaAlive && companionAlive)
        {
            prota.SetActive(false);
            companion.SetActive(true);
        }
        if (!companionAlive && !protaAlive)
        {
            gameObject.SetActive(false);
        }
    }


    //RotateCharacters
    void Rotate()
    {
        RaycastHit hit;
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayo, out hit, float.MaxValue, aimRaycast))
        {
            MousePosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(MousePosition);
        }
    }

    //MoveCharacters
    void Move()
    {
        //moveDirection and move
        MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;
        if (MoveDirection.magnitude == 1) cc.Move(MoveDirection * CharacterStadistics.Speed * WeaponStadistics.Speed * Time.deltaTime);

        //gravity
        if (transform.position.y > 1) cc.SimpleMove(Vector3.down * 5);
    }

    //ChangeCharacters
    void ChangeCharacter()
    {
        prota.SetActive(!prota.activeSelf);         //change
        companion.SetActive(!companion.activeSelf);
        canChange = false;        //cange cooldowns
        Invoke("CanChange", 5f);
    }
    private void CanChange()
    {
        canChange = true;
    }
}
