using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemyMovement : MonoBehaviour
{
    
    enum MovementTipe
    {
        soloSeguir,
        rotaConLerp
    }
    [SerializeField] MovementTipe movementTipe;
    EnemyMovement enemyMovement;
    Enemy2Movement enemy2Movement;
    void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemy2Movement = GetComponent<Enemy2Movement>();
    }
    private void Start()
    {
        if (movementTipe == MovementTipe.soloSeguir)
        {
            enemyMovement.enabled = true;
            enemy2Movement.enabled = false;
        }
        if (movementTipe == MovementTipe.rotaConLerp)
        {
            enemyMovement.enabled = false;
            enemy2Movement.enabled = true;
        }
    }
}
