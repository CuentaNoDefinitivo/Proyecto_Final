using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private float brightness = 1;
    public float Brightness { get { return brightness; } set { brightness = value; } }



    private bool fullScreen = false;
    public bool FullScreen { get => fullScreen; set => fullScreen = value; }

    private void Update()
    {
        if (Screen.fullScreen != fullScreen) Screen.fullScreen = fullScreen;
    }


    public static SettingsManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { DestroyImmediate(this); }
        
    }
}
