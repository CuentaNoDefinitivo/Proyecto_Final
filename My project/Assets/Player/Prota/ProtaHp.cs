using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProtaHp : MonoBehaviour
{

    [SerializeField]private float maxHp = 30;
    private float hp;

    public float Hp { get { return hp; }  set { hp = Mathf.Clamp(value, 0, maxHp); } }
    public float MaxHp { get => maxHp; set => maxHp = value; }
    private void Start()
    {
        hp = maxHp;
    }
    void Update()
    {
        if (hp <= 0)
        {
            this.gameObject.SetActive(false);
            ChangeCharacters.ProtaAlive = false;
        }
    }
}
