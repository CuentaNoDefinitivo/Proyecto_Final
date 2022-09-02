using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCharacters : MonoBehaviour
{
    [SerializeField] float changeCooldown = 6f;
    [SerializeField] Slider protaSlider;
    [SerializeField] Slider companionSlider;

    public static bool ProtaAlive { get; set; }
    public static bool CompanionAlive { get; set; }
    float changeCooldownCount;
    GameObject[] characters;
    bool canChange = true;

    void Start()
    {
        characters = new GameObject[2];

        characters[0] = transform.GetChild(1).gameObject;//prota
        ProtaAlive = true;

        if (transform.childCount == 4)
        {
            characters[1] = transform.GetChild(3).gameObject;//companion
            characters[1].SetActive(false);
            CompanionAlive = true;
        }
        else CompanionAlive = false;
    }

    void Update()
    {
        //cambiar personajes con una tecla.
        if (Input.GetKeyDown(KeyCode.Tab) && canChange && ProtaAlive && CompanionAlive)
        {
            if (characters[0].activeInHierarchy)//¿que diferencia hay entre activeInHierarchy y activeSelf?
            {
                characters[0].SetActive(false);
                characters[1].SetActive(true);
            }
            else
            {
                characters[0].SetActive(true);
                characters[1].SetActive(false);
            }
            canChange = false;
        }

        //si se muere un personaje cambiar al otro
        if (ProtaAlive == false && CompanionAlive)
        {
            characters[1].SetActive(true);
        }
        else if (ProtaAlive && CompanionAlive == false)
        {
            characters[0].SetActive(true);
        }
        else if (!ProtaAlive && !CompanionAlive)
        {
            Debug.Log("Game Over");
            DestroyImmediate(gameObject);
        }


        //UI
        if (canChange == false) { 
            changeCooldownCount += Time.deltaTime;
            if (characters[0].activeSelf)
            {
                companionSlider.maxValue = changeCooldown;
                companionSlider.value = changeCooldown - changeCooldownCount;
                protaSlider.value = protaSlider.maxValue;
            }
            if (characters[1].activeSelf)
            {
                protaSlider.maxValue = changeCooldown;
                protaSlider.value = changeCooldown - changeCooldownCount;
                companionSlider.value = companionSlider.maxValue;
            }
        }
        if (changeCooldownCount >= changeCooldown)
        {
            canChange = true;
            changeCooldownCount = 0;
        }
        if (!ProtaAlive) protaSlider.gameObject.SetActive(false);
        if (!CompanionAlive) companionSlider.gameObject.SetActive(false);
    }
}
