using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;
using System.Collections;
using System;
using FMODUnity;

public class GameHandler : MonoBehaviour
{
    public int[] floorSequence;
    public int floorSequenceIndex = 0;

    public enum GameState {ACTIVE, BROKEN}
    //[HideInInspector] 
    private GameState ritualState; 

    public enum DoorState { Closed, Open, Closing, Opening }
    public DoorState state;

    //private Barrier CheatBarrier; 

    private CameraShake Shake;
    [SerializeField] private GameObject doorLeft, doorRight;


    [Header("Levels")][SerializeField] private GameObject Scene1;

    [SerializeField] GameObject Scene2, Scene3, Scene4, Scene5, Scene8, Scene9;

    [SerializeField] private GameObject ISCENE1, ISCENE2,ISCENE3; 



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

    private bool _gameOver; 


    [HideInInspector] public bool _canInteract; 

    // Start is called before the first frame update
    void Start()
    {

        Scene1.SetActive(true);
        Scene2.SetActive(false);
        Scene3.SetActive(false);
        Scene4.SetActive(false);
        Scene5.SetActive(false);
        Scene8.SetActive(false);
        Scene9.SetActive(false);

        ISCENE1.SetActive(false);
        ISCENE2.SetActive(false);
        ISCENE3.SetActive(false);

        //ISCENE10.SetActive(true);


        ritualState = GameState.ACTIVE; 
        state = DoorState.Opening;
     

        FloorText.text = "1";





    }


    // Update is called once per frame
    void Update()
    {
        RitualCheck();

       


        // player input
        PlayerInput();

        ConditionCheck();

        // dist check 
        MinimalDistCheck();

        /*TEST CODE;

       // print("Can open bool " + CanOpen);
       // print("Can close bool " + CanOpen);
        */
        //Debug.Log("UPDATE");

    }


    private void RitualCheck()
    {
        float elapsed = 0F;
        
        if(_gameOver)
        {
            print("GAME OVER IN CHECK"); 
            elapsed += Time.deltaTime;
            if(elapsed>=3F)
            {
                print("GAME OVER IN timer");
                SceneManager.LoadScene("_EndGame"); 
            }
        }
        
    }


    private void ConditionCheck()
    {
        if (state == DoorState.Opening)
        {
            print("opening"); 
            DoorOpen();
        }
            

        else if (state == DoorState.Closing)
        {
            print("closing"); 
            DoorClose();
        }
            
    }
    #region Input region
    private void PlayerInput()
    {

        if ( state == DoorState.Open)
        {
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                print("CLOSING");
                selectedFloor = 1;
                ClosingDoorSound(); 
                state = DoorState.Closing;
                


            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedFloor = 2;
                ClosingDoorSound();
                state = DoorState.Closing;
                

            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                selectedFloor = 3;
                ClosingDoorSound();
                state = DoorState.Closing;
                
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                selectedFloor = 4;
                ClosingDoorSound();
                state = DoorState.Closing;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                selectedFloor = 5;
                ClosingDoorSound();
                state = DoorState.Closing;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                selectedFloor = 6;
                ClosingDoorSound();
                state = DoorState.Closing;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                selectedFloor = 7;
                ClosingDoorSound();
                state = DoorState.Closing;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                selectedFloor = 8;
                ClosingDoorSound();
                state = DoorState.Closing;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                selectedFloor = 9;
                ClosingDoorSound();
                state = DoorState.Closing;


            }

        }
        

    }

    #endregion

    private void ClosingDoorSound()
    {
        RuntimeManager.PlayOneShot("event:/InGame/Doors");
        //_door.start(); 
    }


    private void SceneLoader(int Floor)
    {
       


        if (ritualState == GameState.ACTIVE)
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
                
                        Scene8.SetActive(false);
                        Scene9.SetActive(false);

                        FloorText.text = "5";

                        break;
                    }

                case 8:
                    {
                        Scene1.SetActive(false);
                        Scene2.SetActive(false);
                        Scene3.SetActive(false);
                        Scene4.SetActive(false);
                        Scene5.SetActive(false); 
       
                        Scene8.SetActive(true); // level 8
                        Scene9.SetActive(false);

                        FloorText.text = "8";

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
       ;
                        Scene8.SetActive(false);
                        Scene9.SetActive(true); // level 9

                        FloorText.text = "9";

                        //StartCoroutine(TimeOutToFinish());

                        //SceneManager.LoadScene("_EndGame");
                        StartCoroutine(GameEnd()); 
                        break;
                    }
                default: { break; }
            }

        }
        else if (ritualState == GameState.BROKEN)
        {
           
            switch (WrongFloor)
            {

                case 2:
                    {
                        // TO DO: 
                        // disable current scene

                        Scene1.SetActive(false); // level 1
                        Scene2.SetActive(false);
                        Scene3.SetActive(false);
                        Scene4.SetActive(false);
                        Scene5.SetActive(false);
          
                        Scene8.SetActive(false);
                        Scene9.SetActive(false);


                        ISCENE1.SetActive(true); 
                        ISCENE2.SetActive(false);

                        FloorText.text = "8";
                        Debug.Log("Scene previous: disabled / Scene 8: enabled");
                        break;
                    }

                case 3:
                    {
                        Scene1.SetActive(false);
                        Scene2.SetActive(false); 
                        Scene3.SetActive(false);
                        Scene4.SetActive(false);
                        Scene5.SetActive(false);
          
                        Scene8.SetActive(false);
                        Scene9.SetActive(false);


                        ISCENE1.SetActive(false); 
                        ISCENE2.SetActive(true);

                        FloorText.text = "9";

                        Debug.Log("Scene 8: disabled / Scene 9: enabled");
                        break;
                    }

                case 4:
                    {
                        Scene1.SetActive(false);
                        Scene2.SetActive(false); 
                        Scene3.SetActive(false);
                        Scene4.SetActive(false);
                        Scene5.SetActive(false);
              
                        Scene8.SetActive(false);
                        Scene9.SetActive(false);

                        //ISCENE10.SetActive(true);

                        ISCENE1.SetActive(false);
                        ISCENE2.SetActive(false);
                        ISCENE3.SetActive(true);

                        FloorText.text = "10";
                        print("GAME OVER IN switch case");
                       
                        Debug.Log("Scene 9: disabled / Scene 10: enabled");

                        StartCoroutine(GameOver()); 
                        //;
                        break;
                    }
                default: { break; }
            }

        }
        state = DoorState.Opening;

        RuntimeManager.PlayOneShot("event:/InGame/Doors");
        



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
                RuntimeManager.PlayOneShot("event:/InGame/LevelArrival"); 
                //_arrival.start();
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
                
     
                state = DoorState.Closed;
                RuntimeManager.PlayOneShot("event:/InGame/QuickSong");
                //_music.start();


                //CheatBarrier.DeactivateColl();
                print("CLOSED");
                CheckSequence();


                if (ritualState == GameState.BROKEN)
                {
                   

                    if(WrongFloor >=3)
                    {
                       
                    }

                }

                // TO DO 
                // CALL IN COROTINA
               
                StartCoroutine(LoadLevel());


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

                //SceneManager.LoadScene("_EndGame"); 
                
                print("final");

                // nivel final
                
                // selected floor = fim 


            }

        }
        else
        {
            WrongFloor++;  // nesse momento é 0 depois passa a 1

            print("errou");
            floorSequenceIndex = 0;

            if (WrongFloor >= 2)
            {
                ritualState = GameState.BROKEN;
             
            }

           
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
        //Shake._canShake = true;
        
        
        yield return new WaitForSeconds(6F);
        SceneLoader(selectedFloor);
        
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3F);
        LoadGameOver(); 
        
    }

    private void LoadGameOver()
    {
        print("Level Game over loaded"); 
        SceneManager.LoadScene("_EndGame");
    }

    private IEnumerator GameEnd()
    {
        yield return new WaitForSeconds(5F);
        LoadGameEnd();

    }

    private void LoadGameEnd()
    {
        print("Level Game over loaded");
        SceneManager.LoadScene("_GameComplete");
    }








}

   
