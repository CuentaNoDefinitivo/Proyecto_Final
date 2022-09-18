using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWeaponData : MonoBehaviour
{
    public Animator characterAnimator;

    Weapon weapon;
    Animator animator;

    private void OnEnable()
    {
        if (transform.childCount == 1)
        {
            SetWeaponAnimationToPlayer();
            SetWeaponStadisticsToPlayer();
        }
        else if (transform.childCount > 1)
        {
            DestroyAllChildren();
        }
    }

    void SetWeaponStadisticsToPlayer()
    {
        if (transform.GetChild(0).TryGetComponent<Weapon>(out weapon))
        {
            if (Player.Instance != null) Player.Instance.WeaponStadistics = weapon.GetWeaponStadistics();
        }
        else
        {
            DestroyAllChildren();
        }
    }
    void SetWeaponAnimationToPlayer()
    {
        if (transform.GetChild(0).TryGetComponent<Animator>(out animator))
        {
            characterAnimator.runtimeAnimatorController = animator.runtimeAnimatorController;
        }
    }

    public void DestroyAllChildren()
    {
        Transform[] childs = GetComponentsInChildren<Transform>();
        
        foreach (Transform child in childs)
        {
            if(child == transform)
            {
                continue;
            }
            Destroy(child.gameObject);
        }
    }
}
