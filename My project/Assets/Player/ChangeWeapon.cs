using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    //Cada personaje tiene dos armas. También puede cambiar a melee.
    GameObject[] weapons;
    
    void Start()
    {
        weapons = new GameObject[2];
        if (transform.childCount == 2)
        {
            weapons[0] = transform.GetChild(0).gameObject;
            weapons[1] = transform.GetChild(1).gameObject;
            weapons[1].SetActive(false);
        }
    }

    
    void Update()
    {
        //cambiar de arma.
        if (Input.GetKeyDown(KeyCode.Q) && weapons[0] != null && weapons[1] != null)
        {
            if (!weapons[0].activeSelf)
            {
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
            }
            else
            {
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
            }
        }

        //desequipar las armas, guardas las armas, o cambiar a melee
        if (Input.GetKeyDown(KeyCode.E))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
        }
    }
}
