using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemies
{
    void Update()
    {
        PerceivePrey();

        if (!preyInArea)
            Patrol();
        else Chase();

        if ((preyPosition - transform.position).magnitude <= 1.3f) Atack();
    }
}
