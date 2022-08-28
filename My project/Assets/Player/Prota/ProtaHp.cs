using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtaHp : MonoBehaviour
{
    public float hp = 30;

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            this.gameObject.SetActive(false);
            ChangeCharacters.ProtaAlive = false;
        }
    }
}
