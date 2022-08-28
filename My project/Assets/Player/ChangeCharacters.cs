using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacters : MonoBehaviour
{
    [SerializeField] float changeCooldown = 6f;

    public static bool ProtaAlive { get; set; }
    public static bool CompanionAlive { get; set; }
    GameObject[] characters;
    bool canChange = true;

    void Start()
    {
        characters = new GameObject[2];

        characters[0] = transform.GetChild(1).gameObject;//prota
        ProtaAlive = true;

        if (transform.childCount == 3)
        {
            characters[1] = transform.GetChild(2).gameObject;//companion
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
            if (characters[0].activeInHierarchy)//¿que diferencia hay entre activeIHierarchy y activeSelf?
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
            Invoke("CanChange", changeCooldown);
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
    }
    private void CanChange()
    {
        canChange = true;
    }
}
