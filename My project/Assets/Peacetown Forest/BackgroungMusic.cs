using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroungMusic : MonoBehaviour
{
    public static BackgroungMusic instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

}
