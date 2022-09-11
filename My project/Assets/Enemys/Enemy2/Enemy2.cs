using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemies
{
    [SerializeField] GameObject bullet;
    float atackTimeCount;
    private void Start()
    {
        Hp = monsterStadistics.Hp; // set hp
    }
    void Update()
    {
        PerceivePrey(); //busca constantemente al player

        if (preyInArea) // si detecta al player ataca y persigue
        {
            atackTimeCount += Time.deltaTime; // empieza contar tiempo
            if (atackTimeCount >= monsterStadistics.AtackSpeed) //si tiempo llega a atackSpeed ataca y resetea el tiempo para seguir contando, instancia un proyectil por cada atackSpeed
            {
                atackTimeCount = 0;
                Atack(); //Shot proyectils
            }
            if((preyPosition - transform.position).magnitude > 5) // le sigue persiguiendo hasta que la distancia llegua a 5u
            {
                Chase();
            }
        }
        else Patrol(); //si no detecta al player patrulla

        //death
        if (Hp <= 0)
        {
            Death();
        }
    }
    protected override void Atack() // cambiar atack por instanciar balas
    {
        Vector3 preyDirection = preyPosition - transform.position;
        Instantiate(bullet,transform.position + Vector3.up, Quaternion.LookRotation(new Vector3(preyDirection.x,0,preyDirection.z),Vector3.up));
    }
}
