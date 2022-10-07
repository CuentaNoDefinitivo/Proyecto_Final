using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionHouse : MonoBehaviour
{
    [SerializeField] GameObject InviteCompanionUI;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) InviteCompanionUI.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) InviteCompanionUI.SetActive(false);
    }
}
