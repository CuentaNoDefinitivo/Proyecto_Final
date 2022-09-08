using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCharacterStadistics : MonoBehaviour
{
    [SerializeField] CharacterStadistic characterStadistics;
    [SerializeField] GameObject characterHUD;
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
        hud = Instantiate(characterHUD, FindObjectOfType<Canvas>().transform);
        hud.transform.SetSiblingIndex(1);
    }
    protected private void SetStadisticsToPlayer()
    {
        transform.parent.GetComponent<Player>().CharacterStadistics = CharacterStadistic;
    }

    protected private void DestroyHUD()
    {
        Destroy(hud);
    }
    protected private void Update()
    {
        if (Hp <= 0)
        {
            if(tag == "Prota")
                transform.parent.GetComponent<Player>().protaAlive = false;
            else
                transform.parent.GetComponent<Player>().companionAlive = false;
        }
        HpHUD.fillAmount = Hp / characterStadistics.MaxHp;
        MpHUD.fillAmount = Mp / characterStadistics.MaxMana;

    }
    protected virtual void SetHUDImage()
    {

    }
}
