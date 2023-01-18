using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadRestart()
    {
        SceneManager.LoadScene("RestartScene");
    }


    // buttons
    public void RetartButton()
    {
        SceneManager.LoadScene("_Game");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("_StartMenu");
    }


}
