using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionStadistics : MonoBehaviour
{
    [SerializeField] float companionSpeed = 5f;
    [SerializeField] float companionDamage = 6f;
    

    void Update()
    {
        PlayerData.CharacterSpeed = companionSpeed;
        PlayerData.CharacterDamage = companionDamage;
    }
}
