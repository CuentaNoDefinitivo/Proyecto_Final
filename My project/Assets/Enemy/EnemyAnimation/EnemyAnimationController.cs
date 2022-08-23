using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(EnemyMovement.Running)
            animator.SetBool("Running", EnemyMovement.Running);
        else
            animator.SetBool("Running", Enemy2Movement.PreyInRange);
    }
}
