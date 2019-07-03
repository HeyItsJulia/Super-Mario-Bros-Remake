// ChangeScene.cs
// Created: 6/28/2019
// Owner: Julia Lundblad
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : UnityEngine.MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("Level 1-1");
    }

    public void GotoControls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
