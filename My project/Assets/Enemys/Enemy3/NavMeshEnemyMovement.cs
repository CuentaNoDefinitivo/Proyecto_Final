using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemyMovement : MonoBehaviour
{
    Vector3 preyPosition;
    bool preyInArea = false;
    NavMeshAgent navMeshAgent;
    Vector3 patrollingPosition;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating("SetRandomPatrollingPosition", 0, 0.5f);
    }

    void Update()
    {
        if (!preyInArea) navMeshAgent.destination = patrollingPosition;
        else navMeshAgent.destination = preyPosition;
    }
    void SetRandomPatrollingPosition()
    {
        //patrollingPosition = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2)) * 20 + transform.position;
        patrollingPosition = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2)).normalized * 30 + transform.position;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player") preyPosition = other.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        { 
            preyInArea = true; 
            CancelInvoke("StopChasing"); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") Invoke("StopChasing", 1.5f);
    }
    private void StopChasing()
    {
        preyInArea = false;
    }
}