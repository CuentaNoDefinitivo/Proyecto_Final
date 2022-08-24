using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion2Stadistics : MonoBehaviour
{
    [SerializeField] float companion2Speed = 10.5f;

    // Update is called once per frame
    void Update()
    {
        PlayerData.CharacterSpeed = companion2Speed;
    }
}
