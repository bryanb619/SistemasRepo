using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ExitGame()
    {
        print("quit"); 
        Application.Quit();
    }

}
