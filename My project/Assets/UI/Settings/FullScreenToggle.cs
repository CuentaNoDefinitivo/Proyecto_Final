using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenToggle : MonoBehaviour
{
    [SerializeField] Toggle fullScreenToggle;
    void Start()
    {
        fullScreenToggle.isOn = Screen.fullScreen;
    }
    void Update()
    {
        fullScreenToggle.isOn = fullScreenToggle.isOn;
    }

    public void SaveFullScreen()
    {
        SettingsManager.Instance.FullScreen = fullScreenToggle.isOn;
    }
}
