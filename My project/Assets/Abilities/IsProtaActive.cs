using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsProtaActive : MonoBehaviour
{
    [SerializeField] GameObject prota;
    public bool protaActive;


    void Update()
    {
         protaActive = prota.activeSelf;
    }
}
