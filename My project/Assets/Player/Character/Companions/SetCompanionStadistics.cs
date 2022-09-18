using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCompanionStadistics : SetCharacterStadistics
{
    void Start()
    {
        Player.equipCompanion += EquipCompanion;
    }

    void EquipCompanion(GameObject companion)
    {
        //DestroyAllChildren / destroy all companionS
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // InstantiateChildren
        Instantiate(companion,transform);
    }
}
