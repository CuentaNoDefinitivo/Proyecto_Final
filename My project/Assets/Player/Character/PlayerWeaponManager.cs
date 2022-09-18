using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    //melee and range weapon references
    [SerializeField] GameObject melee;
    [SerializeField] GameObject[] weapons = new GameObject[2];


    //have weapon1 and 2
    bool haveWeapon1 = false;
    bool haveWeapon2 = false;
    private void Awake()
    {
        HaveWeapon1();
        HaveWeapon2();

        if (haveWeapon1)
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
            melee.SetActive(false);
        }
        else if (haveWeapon2)
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
            melee.SetActive(false);
        }
        else
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            melee.SetActive(true);
        }
    }
    void Update()
    {
        if (haveWeapon1 || haveWeapon2) 
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Space))
            {
                if (transform.GetChild(0).gameObject.activeSelf && haveWeapon2)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                    melee.SetActive(false);
                }
                else if (!transform.GetChild(0).gameObject.activeSelf && haveWeapon1)
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                    melee.SetActive(false);
                }
            } 
        

            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                melee.SetActive(true);
            }
        }
    }

    void HaveWeapon1()
    {
        if (weapons[0].transform.childCount == 1) haveWeapon1 = true;
        else haveWeapon1 = false;
    }
    void HaveWeapon2()
    {
        if (weapons[1].transform.childCount == 1) haveWeapon2 = true;
        else haveWeapon2 = false;
    }
    public bool EquipWeapon(GameObject weapon, Sprite weaponSprite)
    {
        if (!haveWeapon1 || !haveWeapon2)//si no tiene arma1 o no tiene arma2
        {
            if (!haveWeapon1) EquipWeapon1(weapon, weaponSprite);
            else EquipWeapon2(weapon, weaponSprite);

            return true;
        }
        else // si tiene los dos armas
        {
            if (weapons[0].activeSelf) //si está usando arma1
            {
                UnequipWeapon(0);
                EquipWeapon1(weapon, weaponSprite);
                return true;
            }
            else if(weapons[1].activeSelf) //si está usando arma2
            {
                UnequipWeapon(1);
                EquipWeapon2(weapon, weaponSprite);
                return true;
            }
            else return false;
        }
    }
    void EquipWeapon1(GameObject weapon, Sprite weaponSprite)
    {
        haveWeapon1 = true;
        Instantiate(weapon, weapons[0].transform);
        GetComponentInParent<SetAdcCharacterStadistics>().SetWeapon1Image(weaponSprite);

        //acrive weapon1
        weapons[0].SetActive(true);
        weapons[1].SetActive(false);
        melee.SetActive(false);
    }
    void EquipWeapon2(GameObject weapon, Sprite weaponSprite)
    {
        haveWeapon2 = true;
        Instantiate(weapon, weapons[1].transform);
        GetComponentInParent<SetAdcCharacterStadistics>().SetWeapon2Image(weaponSprite);
    }

    void UnequipWeapon(int weapon)
    {
        if (weapon == 0)
        {
            weapons[0].GetComponent<SetWeaponData>().DestroyAllChildren();
            haveWeapon1 = false;
        }
        else if (weapon == 1)
        {
            weapons[1].GetComponent<SetWeaponData>().DestroyAllChildren();
            haveWeapon2 = false;
        }
        else { Debug.LogError("Solo weapon 0 o 1"); }
    }
}
