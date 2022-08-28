using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtaStadistics : MonoBehaviour
{
    [SerializeField] private float protaSpeed = 7;
    [SerializeField] private float protaDamage = 5;

    public float ProtaSpeed { get { return protaSpeed; } set { protaSpeed = value; } }
    public float ProtaDamage { get => protaDamage; set => protaDamage = value; }


    //Otras estadísticas...

}
