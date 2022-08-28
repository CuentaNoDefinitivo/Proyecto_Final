using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaListas : MonoBehaviour
{
    float[] array = new float[3];
    List<float> list = new List<float>();
    Dictionary<string,float> dictionary = new Dictionary<string,float>();
    void Start()
    {
        array[1] = 12;
        //Debug.Log(array[1]);

        list.Add(1);
        list.Add(12);
        list.Add(333);
        Debug.Log(list.Contains(1));//ver si en la lista contiene ese valor, devuelve true si sí, si no, false
        Debug.Log(list[0]);
        //list.RemoveRange(0,2);//remover desde el index hasta count valores atrás
        //list.Remove(1);//remueve el valor
        list.RemoveAt(1);//remueve el valor de la posición
        Debug.Log(list[0]);

        dictionary.Add("primerNumero", 12);
        dictionary.Add("segundoNumero", 19);
        dictionary.Add("tercerNumero", 55);
        dictionary.Remove("tercerNumero");
        Debug.Log(dictionary.ContainsKey("primerNumero"));//preguntar si existe este key
        Debug.Log(dictionary["segundoNumero"]);

        
    }
}
