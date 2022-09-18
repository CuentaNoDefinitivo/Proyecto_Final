using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SetCharacterStadistics : MonoBehaviour
{
    public static Action HpChanged;


    [SerializeField] CharacterStadistic characterStadistics;
    [SerializeField] GameObject characterHUD;
    [SerializeField] GameObject pPVignette;

    protected GameObject hud;
    Image HpHUD;
    Image MpHUD;
    public float Hp { get; set; }
    public float Mp { get; set; }
    public CharacterStadistic CharacterStadistic { get => characterStadistics; }
    protected private void SetProperties()
    {
        HpHUD = GameObject.FindWithTag("HpHUD").GetComponent<Image>();
        MpHUD = GameObject.FindWithTag("MpHUD").GetComponent<Image>();
        Hp = characterStadistics.MaxHp;
    }
    protected private void InstantiateHUD()
    {
        hud = Instantiate(characterHUD, GameObject.FindGameObjectWithTag("MainCanvas").transform);
        hud.transform.SetSiblingIndex(1);
    }
    protected private void SetStadisticsToPlayer()
    {
        transform.parent.GetComponent<Player>().CharacterStadistics = CharacterStadistic;
    }

    protected virtual void SetHUDImage()
    {

    }
    protected virtual void SetHUDBar()
    {
        HpHUD.fillAmount = Hp / characterStadistics.MaxHp;
        MpHUD.fillAmount = Mp / characterStadistics.MaxMana;
    }
    protected virtual void Dead()
    {
        if (Hp <= 0)
        {
            if (tag == "Prota")
            {
                transform.parent.GetComponent<Player>().protaAlive = false;
                transform.GetChild(0).gameObject.SetActive(false);
                GetComponentInChildren<PlayerWeaponManager>().UnequipWeapon(0);
                GetComponentInChildren<PlayerWeaponManager>().UnequipWeapon(1);
            }
            else
                transform.parent.GetComponent<Player>().companionAlive = false;
        }
    }
    public void ReceiveDamage(float damage)
    {
        Hp -= damage;
        HpChanged.Invoke();
    }
    protected void LowHpEfects()
    {
        pPVignette.SetActive(true);
    }
    protected private void DestroyHUD()
    {
        Destroy(hud);
    }
    public void Respawn()
    {
        Hp = characterStadistics.MaxHp;
        transform.GetChild(0).gameObject.SetActive(true);
        HpChanged.Invoke();
    }
    public void Heal(float hp)
    {
        Hp = Mathf.Clamp(Hp + hp, 0, characterStadistics.MaxHp);
        HpChanged.Invoke();
    }
}
