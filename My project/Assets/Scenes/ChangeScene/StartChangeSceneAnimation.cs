using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartChangeSceneAnimation : MonoBehaviour
{
    public void StartAnimation()
    {
        GameObject child = transform.GetChild(0).gameObject;
        child.SetActive(true);
    }
}
