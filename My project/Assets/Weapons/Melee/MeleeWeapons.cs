using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapons : MonoBehaviour
{
    [SerializeField]WeaponStadistics meleWeaponsStadistics;
    protected virtual void Atack()
    {

    }
    private void OnEnable()
    {
        transform.parent.parent.GetComponent<Player>().WeaponStadistics = meleWeaponsStadistics;
    }
}
