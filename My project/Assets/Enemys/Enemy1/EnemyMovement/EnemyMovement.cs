using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float chaseTime = 7f;
    [SerializeField] float restTime = 2f;

    Vector3 preyPosition;
    public static bool Running { get; private set; }
    float chaseTimeCount = 0;
    //Vector3 preyDirection;
    //Vector3 preyDirectionIgnoreY;
    bool preyInRange = false;
    
    void Update()
    {
        Running = false;
        if (preyInRange)
        {
            chaseTimeCount += Time.deltaTime;
            if (chaseTimeCount < chaseTime && (preyPosition - transform.position).magnitude > 0.25f)
            {
                //preyDirectionIgnoreY = new Vector3(preyDirection.x, 0, preyDirection.z).normalized;
                //transform.Translate(preyDirectionIgnoreY * speed * Time.deltaTime);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                transform.LookAt(preyPosition);
                Running = true;
            }
            else if (chaseTimeCount > chaseTime + restTime)
            {
                chaseTimeCount = 0;
            }
        }
        else 
        { 
            chaseTimeCount = 0; 
            //preyDirection = Vector3.zero;
            //preyDirectionIgnoreY = Vector3.zero;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (preyInRange && other.tag == "Player")
        {
            preyPosition = new Vector3(other.transform.position.x, 0, other.transform.position.z);
            //preyDirection = (other.transform.position - transform.position).normalized;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")  preyInRange = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            preyInRange = false;
            chaseTimeCount = 0;
        }
    }
}
