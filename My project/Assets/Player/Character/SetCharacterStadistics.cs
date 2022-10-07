using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SetCharacterStadistics : MonoBehaviour
{
    //Event
    public static Action<float,float> HpChanged; 

    [SerializeField]protected CharacterStadistic characterStadistics;//CharacterStadistics
    public CharacterStadistic CharacterStadistic { get => characterStadistics; }

    //Properties
    public float Hp { get; set; }
    public float Mp { get; set; }

    protected GameObject characterHudReference;
    [SerializeField]protected GameObject characterHUD;
    public GameObject InstanceCharacterHUD { get; set; }



    protected private void SetProperties()
    {
        Hp = characterStadistics.MaxHp;
        InstanceCharacterHUD = characterHUD;
    }

    protected private void InstantiateHUD()
    {
        characterHudReference = Instantiate(InstanceCharacterHUD, GameObject.FindGameObjectWithTag("MainCanvas").transform);
        characterHudReference.transform.SetSiblingIndex(1);
    }
    protected virtual void SetHUDImage()
    {

    }
    protected virtual void SetStadisticsToPlayer()
    {
        transform.parent.GetComponent<Player>().CharacterStadistics = CharacterStadistic;
    }
    
    protected virtual void Dead(float hp, float maxHp)
    {
        if (Hp <= 0)
        {
            if (tag == "Prota")
            {
                transform.parent.GetComponent<Player>().protaAlive = false;
                //transform.GetChild(0).gameObject.SetActive(false);
                gameObject.SetActive(false);
                PlayerWeaponManager thisCharacterWeapon = GetComponentInChildren<PlayerWeaponManager>();
                thisCharacterWeapon.UnequipWeapon(0);
                thisCharacterWeapon.UnequipWeapon(1);
                thisCharacterWeapon.ActiveMelee();

            }
            else
                transform.parent.GetComponent<Player>().companionAlive = false;
        }
    }
    public void ReceiveDamage(float damage)
    {
        Hp -= damage;
        HpChanged?.Invoke(Hp, characterStadistics.MaxHp);
    }
    protected private void DestroyHUD()
    {
        Destroy(characterHudReference);
    }
    public void Respawn()
    {
        Hp = characterStadistics.MaxHp;
        HpChanged.Invoke(characterStadistics.MaxHp, characterStadistics.MaxHp);
    }
    public void Heal(float hp)
    {
        Hp = Mathf.Clamp(Hp + hp, 0, characterStadistics.MaxHp);
        HpChanged.Invoke(Hp, characterStadistics.MaxHp);
    }
}
