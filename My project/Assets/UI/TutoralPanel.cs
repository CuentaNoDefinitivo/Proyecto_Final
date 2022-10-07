using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoralPanel : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;
    }
    public void Close()
    {
        Destroy(transform.parent.gameObject);
    }
    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
