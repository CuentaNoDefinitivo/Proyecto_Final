using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacters : MonoBehaviour
{
    [SerializeField] float changeCooldown = 6f;

    //mi idea de este juego es que el jugador controle dos personajes a la vez, el prota es con el que se identifica, y el acompañante es como el compañero.
    //en un instante solo puede controlar un personaje pero con los controles puede cambiar a otro personaje, y cada personaje tendrá sus propias estadísticas.
    //el prota y el acompañante son hijos del player, así al mover el player, los hijos o sea prota y acompañante moverán de la misma manera.
    GameObject prota;
    GameObject companion;

    bool canChange = true;
    void Start()
    {
        prota = gameObject.transform.GetChild(0).gameObject;
        companion = gameObject.transform.GetChild(1).gameObject;
    }

    void Update()
    {
        //cambiar personajes con una tecla.
        if (Input.GetKeyDown(KeyCode.Tab) && canChange)
        {
            if (prota.activeInHierarchy)//¿que diferencia hay entre activeIHierarchy y activeSelf?
            {
                prota.SetActive(false);
                companion.SetActive(true);
            }
            else
            {
                prota.SetActive(true);
                companion.SetActive(false);
            }
            canChange = false;
            Invoke("CanChange", changeCooldown);
        }
    }
    private void CanChange()
    {
        canChange = true;
    }
}
