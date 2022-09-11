using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MainMenu()
    {
        Invoke("LoadMainMenuScene", 1f);
    }
    public void Game()
    {
        Invoke("LoadGameScene", 1f);
    }
    public void Settings()
    {
        Invoke("LoadSettingsScene", 1f);
    }
    void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    void LoadSettingsScene()
    {
        SceneManager.LoadScene(2);
    }
}
