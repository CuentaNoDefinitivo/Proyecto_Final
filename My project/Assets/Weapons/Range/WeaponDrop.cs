using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDrop : MonoBehaviour
{
    [SerializeField]GameObject weapon;
    [SerializeField] Sprite weaponSprite;
    
    void Start()
    {
        Destroy(gameObject, 20f);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.F) && other.GetComponentInChildren<PlayerWeaponManager>() != null) 
            {
                bool equiped;
                equiped = other.GetComponentInChildren<PlayerWeaponManager>().EquipWeapon(weapon, weaponSprite);
                
                if(equiped)
                Destroy(gameObject);
            }
        }
    }
}
