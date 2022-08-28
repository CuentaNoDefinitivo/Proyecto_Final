using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemyMovement : MonoBehaviour
{

    NavMeshAgent navMeshAgent;
    Vector3 patrollingPosition;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating("SetRandomPatrollingPosition", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = patrollingPosition;
    }
    void SetRandomPatrollingPosition()
    {
        //patrollingPosition = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2)) * 20 + transform.position;
        patrollingPosition = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2)).normalized * 30 + transform.position;
    }
}