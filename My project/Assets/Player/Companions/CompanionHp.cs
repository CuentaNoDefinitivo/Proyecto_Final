using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionHp : MonoBehaviour
{
    [SerializeField] float companionHp;
    public float Hp { get; set; }
    void Start()
    {
        Hp = companionHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            ChangeCharacters.CompanionAlive = false;
            gameObject.SetActive(false);
        }
    }
}
