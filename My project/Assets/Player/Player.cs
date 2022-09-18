using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    //movement
    CharacterController cc;
    Vector3 MoveDirection;

    //rotation
    [SerializeField] LayerMask aimRaycast;
    Vector3 MousePosition;

    //respawn;
    float RespawnTime = 2f;
    [SerializeField]Transform Respawner;



    //---Characters---
    // characterRerefences and ChangeCharacter
    [SerializeField]GameObject prota;
    [SerializeField]GameObject companion;
    bool canChange = true;

    //character state
    public bool protaAlive { get; set; }
    public bool companionAlive { get; set; }
    bool haveCompanion;

    //ScriptableObject, stadistics
    public CharacterStadistic CharacterStadistics { get;  set; }
    public WeaponStadistics WeaponStadistics { get; set; }

    //Animation
    public Animator Animator { get; set; }
    Vector3 animationDirection;
    Vector3 localAnimationDirection;

    //equipCompanion
    public static event Action<GameObject> equipCompanion;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        cc = GetComponent<CharacterController>();
        protaAlive = true;
    }
    void Update()
    {
        if (protaAlive || companionAlive)
        {
            Rotate();
            Move();
        }

        if (haveCompanion)
        {
            if (Input.GetKeyDown(KeyCode.Tab) && canChange && protaAlive && companionAlive) ChangeCharacter(); // if tab && canChange then change.
        }
        PlayerDeath();
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

        animationDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        localAnimationDirection = transform.InverseTransformDirection(animationDirection);
        //moveAnimation
        Animator.SetFloat("Horizontal", localAnimationDirection.x);
        Animator.SetFloat("Vertical", localAnimationDirection.z);

        //gravity
        if (transform.position.y > 1) cc.SimpleMove(Vector3.down * 5);
        else if (transform.position.y < 1) transform.position = new Vector3(transform.position.x,1,transform.position.z);
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

    //equip companion
    public void EquipCompanion(GameObject companion)
    {
        equipCompanion?.Invoke(companion);

        haveCompanion = true;
        companionAlive = true;

        prota.SetActive(false);
        this.companion.SetActive(true);
    }
    
    bool InvokeRespawn = false;
    void PlayerDeath()
    {
        
        if (!protaAlive && !companionAlive)
        {
            if (!InvokeRespawn)
            {
                Invoke("Respawn", RespawnTime);
                InvokeRespawn = true;
            }
            transform.position = Vector3.Lerp(transform.position, Respawner.position, 1 * Time.deltaTime);
        }
    }
    void Respawn()
    {
        protaAlive = true;
        if (haveCompanion) companionAlive = true;
        companion.SetActive(true);
        prota.GetComponent<SetCharacterStadistics>().Respawn();
        transform.position = Respawner.position;
        InvokeRespawn = false;
    }
}
