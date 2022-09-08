using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapons : MonoBehaviour
{
    [SerializeField] protected WeaponStadistics rangeWeaponStadistics;
    [SerializeField] GameObject bullet;
    CharacterStadistic characterStadistics;
    protected float munitionCount;
    protected void Shot()
    {
        var bulletInstance = Instantiate(bullet,transform.position,transform.rotation);
        bulletInstance.GetComponent<Bullet>().CharacterStadistic = characterStadistics;
        munitionCount--;
    }
    protected void GetCharacterDamage()
    {
        characterStadistics = GetComponentInParent<SetCharacterStadistics>().CharacterStadistic;
    }
    private void OnEnable()
    {
        transform.parent.parent.parent.GetComponent<Player>().WeaponStadistics = rangeWeaponStadistics;
    }
}
