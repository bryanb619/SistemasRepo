using UnityEngine;

public class NewPause : MonoBehaviour
{
    // game paused bool
    [HideInInspector]
    public bool _Paused;

    //  Pause Menu Canvas
    [SerializeField]
    public GameObject _pauseMenu;


    private void Start()
    {
        _Paused = false; 
        _pauseMenu.SetActive(false);
    }

    void Update()
    {

        KeyDetect();

    }


    private void KeyDetect()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_Paused)
            {
                
                Resume();
            }
            else
            {
                
                Pause();
            }
            

        }


    }


    private void Resume()
    {
        _pauseMenu.SetActive(false);


        Time.timeScale = 1f;

        _Paused = false;

        LockCursor(); 

        





    }


    private void Pause()
    {
        _pauseMenu.SetActive(true);

        Time.timeScale = 0f;

        _Paused = true;

        FreeCursor();


    }


    private void FreeCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
      
    }


    public void ResumeButton()
    {
        Resume();
    }


    public void QuitButton()
    {
        print("quit");
        Application.Quit();
    }
}
