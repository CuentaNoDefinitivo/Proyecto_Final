using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    //Cada personaje tiene dos armas. También puede cambiar a melee.
    GameObject weapon1;
    GameObject weapon2;
    
    void Start()
    {
        weapon1 = transform.GetChild(0).gameObject;
        weapon2 = transform.GetChild(1).gameObject;
    }

    
    void Update()
    {
        //cambiar de arma.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (weapon1.activeSelf)
            {
                weapon1.SetActive(false);
                weapon2.SetActive(true);
            }
            else
            {
                weapon1.SetActive(true);
                weapon2.SetActive(false);
            }
        }

        //desequipar las armas, guardas las armas, o cambiar a melee
        if (Input.GetKeyDown(KeyCode.E))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(false);
        }
    }
}
