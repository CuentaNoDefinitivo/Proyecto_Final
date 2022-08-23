using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtaStadistics : MonoBehaviour
{
    [SerializeField] float ProtaSpeed = 10;
    [SerializeField] float ProtaDamage = 5;

    //Otras estadísticas...

    void Update()
    {
        //¿hay alguna forma de hacer que esta asignación se haga solo una vez cuando el Prota sea activado?
        //si lo pongo en start cuando
        //desactivo y activo el game object, la variable ya no lo asigna
        PlayerData.CharacterSpeed = ProtaSpeed;
        PlayerData.CharacterDamage = ProtaDamage;
    }
}
