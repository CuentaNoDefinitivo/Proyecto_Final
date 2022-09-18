using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapons : Weapon
{
    Animator characterAnimator;
    [SerializeField]BoxCollider boxCollider;
    private void Start()
    {
        characterAnimator = transform.parent.GetComponent<SetWeaponData>().characterAnimator;
        boxCollider = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !characterAnimator.GetBool("Atack")) Atack();
    }
    protected virtual void Atack()
    {
        characterAnimator.SetBool("Atack", true);
        boxCollider.enabled = true;
        Invoke("DesactiveAtackTrigger", 1);
    }
    void DesactiveAtackTrigger()
    {
        boxCollider.enabled = false;
    }
    private void OnEnable()
    {
        InvokeSetCrosshairType(false);
    }
    private void OnDisable()
    {
        //collider.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NeutralMonster"))
        {
            other.GetComponent<Enemies>().Hp -= 10;
        }
    }
}
