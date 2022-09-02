using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void OnSettingstButtonClicked()
    {
        SceneManager.LoadScene(2);
    }
}
