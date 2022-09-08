using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NewEnemyStadistics", menuName = "NeutralMonster/NormalMonster/NewEnemyStadistics")]
public class NormalNeutralMonsterStadistics : ScriptableObject
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float atackSpeed;
    [SerializeField] float hp;
    [SerializeField] float perceiveArea;
    [SerializeField] float perceiveSpeed = 35f;
    [SerializeField] GameObject[] drops = { };

    public float Speed { get => speed; }
    public float Damage { get => damage; }
    public float AtackSpeed { get => atackSpeed; }
    public float Hp { get => hp; }
    public float PerceiveArea { get => perceiveArea; }
    public float PerceiveSpeed { get => perceiveSpeed; }
    public GameObject[] Drops { get => drops; }
}
