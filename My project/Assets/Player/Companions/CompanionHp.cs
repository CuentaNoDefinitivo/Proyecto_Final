using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanionHp : MonoBehaviour
{
    [SerializeField] float maxHp;
    float hp;
    public float Hp { get { return hp; } set { hp = Mathf.Clamp(value,0,MaxHp); } }
    public float MaxHp { get => maxHp; set => maxHp = value; }

    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            ChangeCharacters.CompanionAlive = false;
            gameObject.SetActive(false);
        }
    }
}
