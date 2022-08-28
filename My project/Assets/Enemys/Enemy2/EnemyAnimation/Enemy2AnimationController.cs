using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AnimationController : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
            animator.SetBool("Running", Enemy2Movement.Running);
    }
}
