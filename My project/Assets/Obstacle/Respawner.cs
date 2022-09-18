using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    float time = 2;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Prota") || other.transform.CompareTag("Companion"))
        {
            time += Time.deltaTime;
            if (time >= 2)
            {
                other.transform.GetComponent<SetCharacterStadistics>().Heal(10);
                time = 0;
            }
        }
        Debug.Log(other.tag);
    }
}
