using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : SetCharacterStadistics
{
    private void Awake()
    {
        SetProperties();
    }
    private void OnEnable()
    {
        InstantiateHUD();
        SetStadisticsToPlayer();
    }
    protected override void SetStadisticsToPlayer()
    {
        transform.parent.parent.GetComponent<Player>().CharacterStadistics = CharacterStadistic;
    }
    private void OnDisable()
    {
        DestroyHUD();
    }
}
