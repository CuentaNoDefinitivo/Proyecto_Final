using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    [SerializeField] float maxFlightTime = 0.3f;
    [SerializeField] float speed = 30;
    //[SerializeField] float destroyTime = 10;


    float time = 0;
    float fallingSpeed = 5;

    private void Start()
    {
        //Destroy(gameObject, destroyTime);
    }
    void Update()
    {
        if (time < maxFlightTime)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            time += Time.deltaTime;
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(90,0,0), 0.1f);
            if (transform.position.y > 0.15f)
            {
                transform.position += Vector3.down * fallingSpeed * Time.deltaTime;
            }
            else DestroyImmediate(this);
        }
    }
}
