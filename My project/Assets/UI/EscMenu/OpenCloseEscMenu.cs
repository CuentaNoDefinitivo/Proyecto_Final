using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseEscMenu : MonoBehaviour
{
    [SerializeField] Slider brightnessSlider;
    [SerializeField] Toggle fullScreenToggle;
    GameObject escMenu;
    void Start()
    {
        escMenu = transform.GetChild(0).gameObject;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            escMenu.SetActive(!escMenu.activeSelf);
            brightnessSlider.value = SettingsManager.Instance.Brightness;
            fullScreenToggle.enabled = Screen.fullScreen;
        }
    }
    public void OnCloseButtonClick()
    {
        escMenu.SetActive(false);
    }
}
