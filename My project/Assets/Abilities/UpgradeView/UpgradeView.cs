using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class UpgradeView : MonoBehaviour
{
    CameraController cameraController;
    bool canUse = true;
    private void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }
    private void Update()
    {
        if (transform.parent.CompareTag("Ability1"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && canUse)
            {
                cameraController.ChangeView(Camera.main.orthographicSize + 5, 10);
                canUse = false;
                Invoke("CanUse", 15);
            }
        }
        else if (transform.parent.CompareTag("Ability2"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha2) && canUse)
            {
                cameraController.ChangeView(Camera.main.orthographicSize + 5, 10);
                canUse = false;
                Invoke("CanUse", 15);
            }
        }
    }
    void CanUse()
    {
        canUse = true;
    }
}
