using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
        SetRig();
    }
    private void OnEnable()
    {
        SetPlayerAnimator();
    }
    void SetRig()
    {
        foreach(Animator a in GetComponentsInChildren<Animator>())
        {
            if (a != null)
            {
                if(a.avatar != null)
                {
                    animator.avatar = a.avatar;
                }
            }
        }
    }
    private void SetPlayerAnimator()
    {
        if(CompareTag("Prota")) transform.parent.GetComponent<Player>().Animator = animator;
        else transform.parent.parent.GetComponent<Player>().Animator = animator;
    }
}
