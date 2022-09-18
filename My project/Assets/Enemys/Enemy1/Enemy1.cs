using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy1 : Enemies
{
    [SerializeField] Animator animator;

    bool atacking = false;
    private void Start()
    {
        Hp = monsterStadistics.Hp;
        MaxHp = monsterStadistics.Hp;
    }
    void Update()
    {
        PerceivePrey(); //buscar al player constantemente

        if (!preyInArea) //si no hay player en area entonces patrulla, si sí, persigue y ataca
            Patrol();
        else
        {
            if ((preyPosition - transform.position).magnitude <= 1.3f && !atacking) { Atack(); atacking = true; }// si se acerca a 1.3u ataca
            else if(!atacking) Chase(); //sino, perseguir
        }

        //Death
        if (Hp <= 0)
        {
            Death();
        }
    }
    protected override void Atack()
    {
        StartCoroutine("AtackAnimation");
    }
    IEnumerator AtackAnimation()
    {
        animator.SetBool("atack", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("atack", false);
        transform.LookAt(new Vector3(preyPosition.x,transform.position.y,preyPosition.z));
        atacking = false;
    }

    protected override void Death()
    {
        base.Death();
        Drop();
    }
}