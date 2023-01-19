using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject scene;

    // Start is called before the first frame update
    void Start()
    {
         scene.SetActive(true);
        Time.timeScale= 1.0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
