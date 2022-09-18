using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemies
{
    [SerializeField] GameObject bullet;
    float atackTimeCount;
    [SerializeField]Animator animator;
    private void Start()
    {
        Hp = monsterStadistics.Hp; // set hp
        MaxHp = monsterStadistics.Hp;
    }
    void Update()
    {
        PerceivePrey(); //busca constantemente al player

        if (preyInArea) // si detecta al player ataca y persigue
        {
            atackTimeCount += Time.deltaTime; // empieza contar tiempo
            if (atackTimeCount >= monsterStadistics.AtackSpeed) //si tiempo llega a atackSpeed ataca y resetea el tiempo para seguir contando, instancia un proyectil por cada atackSpeed
            {
                Atack(); //Shot proyectils
            }
            if ((preyPosition - transform.position).magnitude > 5) // le sigue persiguiendo hasta que la distancia llegua a 5u
            {
                Chase();
            }
            else animator.SetBool("Running", false);
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
        StartCoroutine("AtackAnim");
    }
    IEnumerator AtackAnim()
    {
        animator.SetBool("atack", true);
        transform.LookAt(new Vector3(preyPosition.x, transform.position.y, preyPosition.z));
        yield return new WaitForSeconds(2.5f);
        animator.SetBool("atack", false);
        atackTimeCount = 0;
    }
    protected override void Chase()
    {
        base.Chase();
        animator.SetBool("Running", true);
    }
    protected override void Patrol()
    {
        base.Patrol();
        animator.SetBool("Running", true);
    }
    protected override void Death()
    {
        base.Death();
        Drop();
    }
}
