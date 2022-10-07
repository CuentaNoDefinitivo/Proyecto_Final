using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCompanionStadistics : MonoBehaviour
{
    void Start()
    {
        Player.EquipCompanionEvent += EquipCompanion;
    }
    
    void EquipCompanion(GameObject companion)
    {
        //DestroyAllChildren / destroy all companionS
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // InstantiateCompanionToChildren
        Instantiate(companion,transform);
    }
    private void OnDestroy()
    {
        Player.EquipCompanionEvent -= EquipCompanion;
    }
}
