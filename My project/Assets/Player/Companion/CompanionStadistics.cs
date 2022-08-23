using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionStadistics : MonoBehaviour
{
    [SerializeField] float companionSpeed = 5f;

    

    void Update()
    {
        PlayerData.CharacterSpeed = companionSpeed;
       
    }
}
