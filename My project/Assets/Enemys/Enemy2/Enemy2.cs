using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemies
{
    [SerializeField] GameObject bullet;
    float atackTimeCount;
    void Update()
    {
        PerceivePrey();
        if (preyInArea)
        {
            
            atackTimeCount += Time.deltaTime;
            if (atackTimeCount >= monsterStadistics.AtackSpeed)
            {
                atackTimeCount = 0;
                Atack();
            }
            if((preyPosition - transform.position).magnitude > 5)
            {
                Chase();
            }
        }
        else Patrol();
    }
    protected override void Atack()
    {
        Vector3 preyDirection = preyPosition - transform.position;
        Instantiate(bullet,transform.position + Vector3.up, Quaternion.LookRotation(new Vector3(preyDirection.x,0,preyDirection.z),Vector3.up));
    }
}
