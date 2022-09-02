using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesCompanion2 : MonoBehaviour
{
    [SerializeField] GameObject knife;
    //[SerializeField] DaggeTrigger daggeTrigger;
    //[SerializeField] KnifeMovement knifeMovement;
    List<Transform> _daggerList;
    bool habilidad2Active = false;
    float numDaggeReturned;

    float destroyDaggeTime = 0;

    private void Start()
    {
        _daggerList = new List<Transform>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Ability1();
        if (Input.GetKeyUp(KeyCode.Q)) habilidad2Active = true;
        if (habilidad2Active) Ability2();

        //empezar a contar tiempo si la lista de daga no está vacía
        if (_daggerList.Count != 0)   destroyDaggeTime += Time.deltaTime;
        else    destroyDaggeTime = 0;
        // si ya contado hasta diez destruir la primera daga y resetear el contador.
        if (destroyDaggeTime >= 10)
        {
            Destroy(_daggerList[0].gameObject);
            _daggerList.RemoveAt(0);
            destroyDaggeTime = 0;
        }

    }

    void Ability1()
    {
        var newKnife = Instantiate(knife,transform.position, transform.rotation);
        //_daggerList = knifeMovement.daggerListReference;
        newKnife.GetComponent<DaggeTrigger>().CharacterDamage = GetComponentInParent<CompanionStadistics>().CompanionDamage;
        _daggerList.Add(newKnife.transform);
    }
    void Ability2()
    {
        //mover todas las dagas
        foreach(Transform knife in _daggerList)
        {
            knife.transform.position += (transform.position - knife.transform.position).normalized * 40 * Time.deltaTime;
            knife.transform.LookAt(transform);
        }

        if(numDaggeReturned == _daggerList.Count)//si num de daga vuelto es igual que num de dagas.
        {
            //destruye todas las dagas
            foreach(Transform knife in _daggerList)
            {
                DestroyImmediate(knife.gameObject);
            }
            //resetear todas las variables
            _daggerList.Clear();
            habilidad2Active = false;
            numDaggeReturned = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Companion2Dagge")) numDaggeReturned++;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Companion2Dagge")) numDaggeReturned--;
    }
}
