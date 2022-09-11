using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemies
{
    [SerializeField] Animator animator;
    private void Start()
    {
        Hp = monsterStadistics.Hp;
    }
    void Update()
    {
        PerceivePrey(); //buscar al player constantemente

        if (!preyInArea) //si no hay player en area entonces patrulla, si sí, persigue y ataca
            Patrol();
        else
        {
            //if ((preyPosition - transform.position).magnitude <= 1.3f) Atack(); // si se acerca a 1.3u ataca
            Chase();
        }

        //Death
        if (Hp <= 0)
        {
            Death();
        }
    }
    protected override void Atack()
    {
        animator.SetBool("atack", true);
        Invoke("ResetAtack",0.4f);
    }
    private void ResetAtack()
    {
        animator.SetBool("atack", false);
    }
}