using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NewCharacterStadistics", menuName = "Characters/CharacterStadistics")]
public class CharacterStadistic : ScriptableObject
{
    [SerializeField] float maxHp;
    [SerializeField] float maxMana;

    [SerializeField] float speed;
    [SerializeField] float damage;

    [SerializeField] Avatar characterRig; 




    public float MaxHp { get => maxHp; set => maxHp = value; }
    public float MaxMana { get => maxMana; set => maxMana = value; }
    public float Speed { get => speed; set => speed = value; }
    public float Damage { get => damage; set => damage = value; }
    public Avatar CharacterRig { get => characterRig; }
}
