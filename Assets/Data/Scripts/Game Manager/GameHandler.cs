using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;
using System.Collections;
using System;
using FMODUnity;
using UnityEngine.Events; 

public class GameHandler : MonoBehaviour
{
    public int[] floorSequence;
    public int floorSequenceIndex = 0;

    public enum GameState { ACTIVE, BROKEN}
    private GameState ritualState; 

    public enum DoorState { Closed, Open, Closing, Opening }
    public DoorState state;

    private Barrier CheatBarrier; 

    private CameraShake Shake;
    [SerializeField] private GameObject doorLeft, doorRight;


    [Header("Levels")][SerializeField] private GameObject Scene1;

    [SerializeField] GameObject Scene2, Scene3, Scene4, EndScene;

    [SerializeField] private GameObject Scene5, Scene6, Scene7, Scene8, Scene9;



    // Open and close distance checkers
    [Tooltip("Door Config")]
    [SerializeField] private GameObject OpenPosLeft, OpenPosRight, ClosePosLeft, ClosePosRight;


    //  Condition to open doors
    //public bool _canInteract;

    private int selectedFloor;


    private int WrongFloor = 0; 


    // level input bools

    [Header("Door Configuration")]
    [Range(1, 5)]
    private float speed = 1f;

    [SerializeField]
    private
        TextMeshProUGUI FloorText;


    // FMOD

 
   


    //bools 


    [HideInInspector] public bool _canInteract; 

    // Start is called before the first frame update
    void Start()
    {
        RuntimeManager.PlayOneShot("event:/InGame/LevelArrival");
        RuntimeManager.PlayOneShot("event:/InGame/Doors");

        ritualState = GameState.ACTIVE; 
        state = DoorState.Opening;

        FloorText.text = "1";
        

        Shake = FindObjectOfType<CameraShake>();

        CheatBarrier = GetComponentInChildren<Barrier>();   



        Scene1.SetActive(true);
        Scene2.SetActive(false);
        Scene3.SetActive(false);
        Scene4.SetActive(false);
        Scene5.SetActive(false);
        Scene6.SetActive(false);
        Scene7.SetActive(false);
        Scene8.SetActive(false);
        Scene9.SetActive(false);


        //IScene2.SetActive(false);
        //IScene3.SetActive(false);
        //IScene4.SetActive(false);
      
        



    }

    // Update is called once per frame
    void Update()
    {

        ConditionCheck(); 


        // player input
        PlayerInput();

        // dist check 
        MinimalDistCheck();

        /*TEST CODE;

       // print("Can open bool " + CanOpen);
       // print("Can close bool " + CanOpen);
        */
        //Debug.Log("UPDATE");

    }

    private void ConditionCheck()
    {
        if (state == DoorState.Opening)
        {
            
            DoorOpen();
        }
            

        else if (state == DoorState.Closing)
            DoorClose();
    }
    #region Input region
    private void PlayerInput()
    {

        if (_canInteract && state == DoorState.Open)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                print("CLOSING");
                selectedFloor = 1;
                state = DoorState.Closing;

                
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedFloor = 2;
                state = DoorState.Closing;

            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                selectedFloor = 3;
                state = DoorState.Closing;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                selectedFloor = 4;
                state = DoorState.Closing;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                selectedFloor = 5;
                state = DoorState.Closing;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                selectedFloor = 6;
                state = DoorState.Closing;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                selectedFloor = 7;
                state = DoorState.Closing;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                selectedFloor = 8;
                state = DoorState.Closing;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                selectedFloor = 9;
                state = DoorState.Closing;
            }

        }
        

    }

    #endregion

    


    private void SceneLoader(int Floor)
    {
        if(ritualState == GameState.ACTIVE)
        {
            switch (Floor)
            {

                case 1:
                    {
                        // TO DO: 
                        // disable current scene

                        Scene1.SetActive(true); // level 1
                        Scene2.SetActive(false);
                        Scene3.SetActive(false);
                        Scene4.SetActive(false);
                        Scene5.SetActive(false);
                        Scene6.SetActive(false);
                        Scene7.SetActive(false);
                        Scene8.SetActive(false);
                        Scene9.SetActive(false);

                        FloorText.text = "1";
                        Debug.Log("Scene 1: disabled / Scene 2: enabled");
                        break;
                    }

                case 2:
                    {
                        Scene1.SetActive(false);
                        Scene2.SetActive(true); // level 2
                        Scene3.SetActive(false);
                        Scene4.SetActive(false);
                        Scene5.SetActive(false);
                        Scene6.SetActive(false);
                        Scene7.SetActive(false);
                        Scene8.SetActive(false);
                        Scene9.SetActive(false);

                        FloorText.text = "2";

                        Debug.Log("Scene 2: disabled / Scene 3: enabled");
                        break;
                    }

                case 3:
                    {
                        Scene1.SetActive(false);
                        Scene2.SetActive(false);
                        Scene3.SetActive(true); // level 3
                        Scene4.SetActive(false);
                        Scene5.SetActive(false);
                        Scene6.SetActive(false);
                        Scene7.SetActive(false);
                        Scene8.SetActive(false);
                        Scene9.SetActive(false);

                        FloorText.text = "3";

                        Debug.Log("Scene 3: disabled / Scene 4: enabled");
                        break;
                    }

                case 4:
                    {
                        Scene1.SetActive(false);
                        Scene2.SetActive(false);
                        Scene3.SetActive(false);
                        Scene4.SetActive(true); // level 4 
                        Scene5.SetActive(false);
                        Scene6.SetActive(false);
                        Scene7.SetActive(false);
                        Scene8.SetActive(false);
                        Scene9.SetActive(false);

                        FloorText.text = "4";


                        break;
                    }
                case 5:
                    {
                        Scene1.SetActive(false);
                        Scene2.SetActive(false);
                        Scene3.SetActive(false);
                        Scene4.SetActive(false);
                        Scene5.SetActive(true); // level 5
                        Scene6.SetActive(false);
                        Scene7.SetActive(false);
                        Scene8.SetActive(false);
                        Scene9.SetActive(false);

                        FloorText.text = "5";

                        //SceneManager.LoadScene("_EndGame");

                        break;
                    }
                case 9:
                    {
                        Scene1.SetActive(false);
                        Scene2.SetActive(false);
                        Scene3.SetActive(false);
                        Scene4.SetActive(false);
                        Scene5.SetActive(false);
                        Scene6.SetActive(false);
                        Scene7.SetActive(false);
                        Scene8.SetActive(false);
                        Scene9.SetActive(true); // level 9

                        FloorText.text = "9";

                        //SceneManager.LoadScene("_EndGame");

                        break;
                    }
                default: { break; }
            }

        }
        else if (ritualState == GameState.BROKEN)
        {
            switch (WrongFloor)
            {

                case 1:
                    {
                        // TO DO: 
                        // disable current scene

                        Scene1.SetActive(false); // level 1
                        Scene2.SetActive(false);
                        Scene3.SetActive(false);
                        Scene4.SetActive(false);
                        Scene5.SetActive(false);
                        Scene6.SetActive(true);
                        Scene7.SetActive(false);
                        Scene8.SetActive(false);
                        Scene9.SetActive(false);

                        FloorText.text = "8";
                        Debug.Log("Scene previous: disabled / Scene 8: enabled");
                        break;
                    }

                case 2:
                    {
                        Scene1.SetActive(false);
                        Scene2.SetActive(false); // level 2
                        Scene3.SetActive(false);
                        Scene4.SetActive(false);
                        Scene5.SetActive(false);
                        Scene6.SetActive(false);
                        Scene7.SetActive(true);
                        Scene8.SetActive(false);
                        Scene9.SetActive(false);

                        FloorText.text = "9";

                        Debug.Log("Scene 8: disabled / Scene 9: enabled");
                        break;
                    }

                case 3:
                    {
                        Scene1.SetActive(false);
                        Scene2.SetActive(false); // level 2
                        Scene3.SetActive(false);
                        Scene4.SetActive(false);
                        Scene5.SetActive(false);
                        Scene6.SetActive(false);
                        Scene7.SetActive(false);
                        Scene8.SetActive(true);
                        Scene9.SetActive(false);

                        FloorText.text = "10";

                        Debug.Log("Scene 9: disabled / Scene 10: enabled");
                        break;
                    }
                default: { break; }
            }

        }





        // dispara 

        // TO DO
        // ADD SOM 

        
        RuntimeManager.PlayOneShot("event:/InGame/LevelArrival");


        state = DoorState.Opening;

    }
    private void MinimalDistCheck()
    {

        if (state == DoorState.Opening)
        {
            float minDist = 0.1f;
            bool leftOpen = false;
            bool RightOpen = false;

            

            //CheatBarrier.DeactivateColl();

            if ((OpenPosLeft.transform.position - doorLeft.transform.position).magnitude < minDist)
            {
                doorLeft.transform.position = OpenPosLeft.transform.position;


                leftOpen = true;

            }

            if ((OpenPosRight.transform.position - doorRight.transform.position).magnitude < minDist)
            {
                doorRight.transform.position = OpenPosRight.transform.position;
                RightOpen = true;
            }

            if (leftOpen && RightOpen)
            {
                state = DoorState.Open;
                //_canInteract = true;

                //_openInput = false;
                //_closeInput = true;

                //_canOpen = false;
                //_canClose = true;
                //Doors();
                print("OPEN");

            }

        }

        else if (state == DoorState.Closing)
        {
            float CloseDist = 0.1f;

            bool leftClosed = false;
            bool RightClosed = false;

            //CheatBarrier.ActivateColl();



            if ((ClosePosLeft.transform.position - doorLeft.transform.position).magnitude < CloseDist)
            {
                doorLeft.transform.position = ClosePosLeft.transform.position;
                leftClosed = true;
            }
            if ((ClosePosRight.transform.position - doorRight.transform.position).magnitude < CloseDist)
            {
                doorRight.transform.position = ClosePosRight.transform.position;
                RightClosed = true;

            }

            if (leftClosed && RightClosed)
            {
                
                //_canInteract = true;
                //_closeInput = false;

                //_canOpen = true;
                //_canClose = false;
                state = DoorState.Closed;
                RuntimeManager.PlayOneShot("event:/InGame/QuickSong");

                //CheatBarrier.DeactivateColl();
                print("CLOSED");
                CheckSequence();


                if (ritualState == GameState.BROKEN)
                {
                    WrongFloor++;

                }

                // TO DO 
                // CALL IN COROTINA
               

                StartCoroutine(LoadLevel());
                //StartCoroutine(TimeOut());


                //SceneLoader(selectedFloor);


            }

         

        }

    }

    private void CheckSequence()
    {
        if (floorSequence[floorSequenceIndex] == selectedFloor)
        {
            // to do 
            // garantir que floor index nao é out of bounds

            ritualState= GameState.ACTIVE;  
            floorSequenceIndex++;
            if (floorSequenceIndex == floorSequence.Length)
            {

                SceneManager.LoadScene("_EndGame"); 
                
                print("final");

                // nivel final

                // selected floor = fim 


            }

        }
        else
        {

            ritualState = GameState.BROKEN; 
            print("errou");
            floorSequenceIndex = 0;
        }
    }

    private void DoorOpen()
    {
        //Debug.Log("ABRE");


        doorLeft.transform.Translate(Vector3.left * speed * Time.deltaTime); // move left door left
        doorRight.transform.Translate(Vector3.right * speed * Time.deltaTime);// move right door rigt
    }

    private void DoorClose()
    {
        //Debug.Log("FECHA");
        doorLeft.transform.Translate(Vector3.right * speed * Time.deltaTime); // move left door right
        doorRight.transform.Translate(Vector3.left * speed * Time.deltaTime); // move right door left
    }

    private IEnumerator LoadLevel()
    {
        Shake._canShake = true;
        
        
        yield return new WaitForSeconds(6F);
        
        
        
        Shake._canShake = false;
        RuntimeManager.PlayOneShot("event:/InGame/Doors");
        SceneLoader(selectedFloor);
        
    }

    private void OnDestroy()
    {
       
    }

    

}

   
