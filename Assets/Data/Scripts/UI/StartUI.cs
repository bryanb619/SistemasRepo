using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class StartUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }


    public void LoadGame()
    {
        SceneManager.LoadScene("Game"); 
    }

    public void GameQuit()
    {
        print("quit");
        Application.Quit();
    }

}
