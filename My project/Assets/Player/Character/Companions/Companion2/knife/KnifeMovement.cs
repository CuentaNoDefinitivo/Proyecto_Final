using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    [SerializeField] float maxFlightTime = 0.3f;
    [SerializeField] float speed = 30;
    [SerializeField] CharacterStadistic characterStadistic;

    float time = 0;
    float fallingSpeed = 5;

    bool hability2Actived = false;
    public Transform companion2Reference;
    private void Start()
    {
        Destroy(gameObject, 20f);
        Companion2.Companion2Hability2 += Hability2Actived;
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
        }
        if (hability2Actived) hability2();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NeutralMonster")
        {
            other.GetComponent<Enemies>().Hp -= characterStadistic.Damage;
        }
    }
    void Hability2Actived()
    {
        hability2Actived = true;
    }
    void hability2()
    {
        if (Mathf.Round(transform.position.x * 100) != Mathf.Round(companion2Reference.position.x * 100) && Mathf.Round(transform.position.y * 100) != Mathf.Round(companion2Reference.position.y * 100) && Mathf.Round(transform.position.z * 100) != Mathf.Round(companion2Reference.position.z * 100))
        {
            transform.LookAt(companion2Reference);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else DestroyImmediate(gameObject);
    }
    private void OnDestroy()
    {
        Companion2.Companion2Hability2 -= Hability2Actived;
    }
}
