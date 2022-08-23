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
    Vector3 preyDirection;
    Vector3 preyDirectionIgnoreY;
    bool preyInRange = false;
    
    void Update()
    {
        Running = false;
        if (preyInRange)
        {
            chaseTimeCount += Time.deltaTime;
            if (chaseTimeCount < chaseTime)
            {
                preyDirectionIgnoreY = new Vector3(preyDirection.x, 0, preyDirection.z).normalized;
                //transform.Translate(preyDirectionIgnoreY * speed * Time.deltaTime);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                transform.LookAt(new Vector3(preyPosition.x,0,preyPosition.z));
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
            preyDirection = Vector3.zero;
            preyDirectionIgnoreY = Vector3.zero;
        }
        Debug.Log(Running);
    }
    private void OnTriggerStay(Collider other)
    {
        if (preyInRange)
        {
            preyPosition = other.transform.position;
            preyDirection = (other.transform.position - transform.position).normalized;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")  preyInRange = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")  preyInRange = false;
    }
}
