using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField]public UnityEvent StartButtonEvents;
    [SerializeField]public UnityEvent SettingsButtonEvent;
    public void OnStartButtonClicked()
    {
        StartButtonEvents?.Invoke();
    }
    public void OnSettingsButtonClicked()
    {
        SettingsButtonEvent?.Invoke();
    }
}
