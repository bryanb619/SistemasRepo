using UnityEngine;

// automaticly require Character Controller
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // Variables

    // player speed
    [Header("Player Speed")]
    [SerializeField] private float walkingSpeed = 5.0f;

    // Graavity basics
    [Header("Player Gravity")]
    [SerializeField] private float gravity = 20.0f;
    // Player camera
    [Header("Player Camera")]
    [SerializeField] private Camera playerCamera;
    // Look Speed
    [SerializeField] private float lookSpeed = 2.0f;
    // Camera X limitation
    [SerializeField] private float lookXLimit = 45.0f;

    [HideInInspector]
    public bool CanMove; 

    // Character Controller
    CharacterController characterController;
    
    // Vector motion
    Vector3 moveDirection = Vector3.zero;
    // player rotation
    float rotationX = 0;

    // can player move
    
    public bool Move = true;

    void Start()
    {
        CanMove= true;

   
        // Get Character controller
        characterController = GetComponent<CharacterController>();

        // Lock and hide cursor
        HideCursor();
    }

    void Update()
    {
        // detect player motion

        if (Move) 
        {
           DetectMotion();
        }
        // Player and Camera rotation
        if (CanMove)
        {
            rotationX += -Input.GetAxis("Mouse_Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse_X") * lookSpeed, 0);
        }


    }

    void DetectMotion()
    {
        
        // When grounded  are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Left Shift to run
      
        float curSpeedX = CanMove ? (walkingSpeed) * Input.GetAxis("Forward") : 0;
        float curSpeedY = CanMove ? (walkingSpeed) * Input.GetAxis("Strafe") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        /*
        if (Input.GetButton("Jump") && CanMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        */

       
        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;

        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        
    }

    private void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    

}