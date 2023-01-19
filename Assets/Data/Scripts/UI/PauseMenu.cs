using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    // game paused bool
    [HideInInspector]
    public bool _Paused = false;

    //  Pause Menu Canvas
    [SerializeField]
    public GameObject  _pauseMenu;

    // Event Sy




    private void Start()
    {
   
  
        _pauseMenu.SetActive(false);

        //GamePlay.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        KeyDetect();

    }
    
    void FixedUpdate()
    {
        if (!_Paused)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (_Paused == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

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

    // method Resume
    private void Resume()
    {

        _pauseMenu.SetActive(false);


        Time.timeScale = 1f;

        _Paused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


    }
    // method pause
    private void Pause()
    {


        _pauseMenu.SetActive(true);
        //GamePlay.SetActive(false);

        Time.timeScale = 0f;

        _Paused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
       
    }

    // buttons 

    // Pause Menu
    public void ResumeButton()
    {
        Resume();

    }

    public void GameQuit()
    {
        Application.Quit();
    }

    // Options Menu

    // BACK BUTTON

   



}
