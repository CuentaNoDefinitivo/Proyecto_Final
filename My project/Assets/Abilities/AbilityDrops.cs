using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDrops : MonoBehaviour
{
    [SerializeField] GameObject ability;
    [SerializeField] string abilityName;
    [SerializeField] Sprite abilitySprite;
    [SerializeField] GameObject takeAbilityTutorial;
    void Start()
    {
        transform.rotation = Quaternion.Euler(90,0,0);
        Destroy(gameObject, 20f);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.F) && other.GetComponentInChildren<PlayerAbilityManager>() != null) 
            {
                bool equiped;
                equiped = other.GetComponentInChildren<PlayerAbilityManager>().EquipAbilities(ability, abilitySprite, abilityName);
                
                if(equiped)
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))takeAbilityTutorial.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))takeAbilityTutorial.SetActive(false);
    }
}
