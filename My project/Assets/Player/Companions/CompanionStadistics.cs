using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionStadistics : MonoBehaviour
{
    [SerializeField] float companionSpeed = 5f;
    [SerializeField] float companionDamage = 6f;

    public float CompanionSpeed { get => companionSpeed; set => companionSpeed = value; }
    public float CompanionDamage { get => companionDamage; set => companionDamage = value; }
}