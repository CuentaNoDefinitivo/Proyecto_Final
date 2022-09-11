using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableAtackTrigger : MonoBehaviour
{
    [SerializeField] BoxCollider atackTrigger;

    public void EnableOrDisable()
    {
        atackTrigger.enabled = !atackTrigger.enabled;
    }
}
