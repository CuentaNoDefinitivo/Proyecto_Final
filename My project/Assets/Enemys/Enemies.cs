using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    public float Hp { get; set; }
    [SerializeField] protected NormalNeutralMonsterStadistics monsterStadistics;
    [SerializeField] protected LayerMask enemyDetectionLayer;
    protected bool preyInArea = false;
    protected Vector3 preyPosition;
    float rayRotateAngle;
    RaycastHit hit; 
    [SerializeField]protected NavMeshAgent navMeshAgent;
    protected virtual void Atack()
    {
        Debug.Log("atack");
    }
    protected virtual void Chase()
    {
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
        float angle = Random.Range(0f, 360f);
        return new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
    }



    protected virtual void PerceivePrey() // un raycastGirando
    {
        //aumentar el angulo cuando pasa el tiempo
        rayRotateAngle += Time.deltaTime * 50f;
        Ray perceivePreyRay = new Ray(transform.position + Vector3.up, new Vector3(Mathf.Sin(rayRotateAngle), 0, Mathf.Cos(rayRotateAngle)));
        if (Physics.Raycast(perceivePreyRay, out hit, monsterStadistics.PerceiveArea, enemyDetectionLayer)) 
        {
            if (hit.transform.CompareTag("Player"))    
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
        DestroyImmediate(gameObject);
    }
}
