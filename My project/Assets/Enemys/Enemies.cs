using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    //Stadistics
    public float MaxHp { get; protected set; }
    public float Hp { get; set; }

    [SerializeField] protected NormalNeutralMonsterStadistics monsterStadistics;


    //ray
    float rayRotateAngle;
    [SerializeField] protected LayerMask enemyDetectionLayer;
    RaycastHit hit;

    protected bool preyInArea = false;
    protected Vector3 preyPosition;
     
    [SerializeField]protected NavMeshAgent navMeshAgent;


    //spawner
    public GameObject spawner;
    protected virtual void Atack()
    {
        
    }
    protected virtual void Chase()
    {
        /*transform.LookAt(preyPosition);
        transform.Translate(Vector3.forward * Time.deltaTime * 2);*/
        navMeshAgent.destination = preyPosition;
    }


    float patrolTimeCount = 1;
    protected virtual void Patrol()
    {
        patrolTimeCount += Time.deltaTime;
        if (patrolTimeCount >= 2f)
        {
            patrolTimeCount = 0;
            navMeshAgent.destination = transform.position + GetRandomDirection() * 20;
        }
    }
    protected Vector3 GetRandomDirection()
    {
        float angle = UnityEngine.Random.Range(0f, 360f);
        return new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
    }

/*
    protected virtual void PerceivePrey()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,monsterStadistics.PerceiveArea,enemyDetectionLayer,QueryTriggerInteraction.Ignore);
        if(colliders.Length > 0)
        {
            preyInArea = true;
            preyPosition = colliders[0].transform.position;
            preyPosition.y = 0;
        }
        else preyInArea = false;
    }*/
    
    protected virtual void PerceivePrey() // un raycastGirando
    {
        //aumentar el angulo cuando pasa el tiempo
        rayRotateAngle += Time.deltaTime * 50f;

        Ray perceivePreyRay = new Ray(transform.position + Vector3.up, new Vector3(Mathf.Sin(rayRotateAngle), 0, Mathf.Cos(rayRotateAngle)));
        if (Physics.Raycast(perceivePreyRay, out hit, monsterStadistics.PerceiveArea, enemyDetectionLayer)) 
        {
            if (hit.transform.CompareTag("Player"))//Player encontrado
            {
                CancelInvoke("ResetPreyInArea");
                preyInArea = true;
                preyPosition = hit.point;
                
            }
        }
        if(!Physics.Raycast(perceivePreyRay, out hit, monsterStadistics.PerceiveArea, enemyDetectionLayer) || !hit.transform.CompareTag("Player"))   Invoke("ResetPreyInArea", 2.3f);


        //dibujar raycast
        Debug.DrawRay(transform.position + Vector3.up, new Vector3(Mathf.Sin(rayRotateAngle) * monsterStadistics.PerceiveArea, 0, Mathf.Cos(rayRotateAngle) * monsterStadistics.PerceiveArea),Color.red);


        //prevenir que el angulo se pase del float.MaxValue
        if (rayRotateAngle > 360)  rayRotateAngle = 0; 
    }
    void ResetPreyInArea()
    {
        preyInArea = false;
    }
    protected virtual void Death()
    {
        Destroy(gameObject);
        spawner.GetComponent<EnemyRespawn>().enemyCount--;
    }
    protected virtual void Drop()
    {
        int random = UnityEngine.Random.Range(1, 3); //random 1 o 2;

        if (random == 2) //solo si es 2 dropea. 50%
        {
            int randomDrop = UnityEngine.Random.Range(0, monsterStadistics.Drops.Length); //seleccionar random de todos los elementos que puede dropear
            Instantiate(monsterStadistics.Drops[randomDrop], transform.position + Vector3.up, transform.rotation); //dropear ese elemento
        }
    }
}