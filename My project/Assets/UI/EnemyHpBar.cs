using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    Enemies enemies;
    Image image;

    void Start()
    {
        enemies = transform.parent.parent.GetComponent<Enemies>();
        image = GetComponent<Image>();
    }
    void Update()
    {
        image.fillAmount = enemies.Hp / enemies.MaxHp;
    }
}
