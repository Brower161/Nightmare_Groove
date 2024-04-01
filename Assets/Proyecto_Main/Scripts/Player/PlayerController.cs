using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public Animator playerAnim;
    public GameObject camHolder;
    //private CharacterController characterController;
    public float crouchSpeed, walkSpeed, currentSpeed, runSpeed, sensitivity, maxForce;
    public AudioSource footSteps;
    //public PlayerInput playerInput;

    private Vector2 move, look, playerInput;
    private float lookRotation;
    private bool isRunning, isCrouching;
    bool footstepsAreSounding;
    [SerializeField] float footstepsDelay;

    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        footstepsAreSounding = false;

        currentSpeed = walkSpeed;

        //characterController = GetComponent<CharacterController>();
    }

    void LateUpdate()
    {
        Look();
    }

    private void Update()
    {
        playerAnim.SetBool("isCrouching", isCrouching);

        
        if (playerRb.velocity != Vector3.zero && !footstepsAreSounding)
        {
            footstepsAreSounding = true;
            footSteps.PlayOneShot(footSteps.clip);
            Invoke("ResetFootStepsSound", footstepsDelay);

            //playerAnim.SetFloat("Moving", 1);
        }
        
        if (isCrouching == true)
        {
            currentSpeed = crouchSpeed;
            isRunning = false;
        }
        else
        {
            currentSpeed = walkSpeed;
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //characterController.Move(direction * speed * Time.deltaTime);
        
        //Find target velocity
        Vector3 currentVelocity = playerRb.velocity;
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y);
        targetVelocity *= isRunning ? runSpeed : currentSpeed;

        //Align direction
        targetVelocity = transform.TransformDirection(targetVelocity);

        //Calculate forces
        Vector3 velocityChange = (targetVelocity - currentVelocity);
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);

        //Limit force
        Vector3.ClampMagnitude(velocityChange, maxForce);

        playerRb.AddForce(velocityChange, ForceMode.VelocityChange);


        //DRAG

        /*if (targetVelocity == Vector3.zero) playerRb.drag = 100;
        else
        {
            playerRb.drag = 0;
        }*/
    }

    void Look()
    {
        //Turn
        transform.Rotate(Vector3.up * look.x * sensitivity);

        //Look
        lookRotation += (-look.y * sensitivity);
        lookRotation = Mathf.Clamp(lookRotation, -90, 90);
        camHolder.transform.eulerAngles = new Vector3(lookRotation, camHolder.transform.eulerAngles.y, camHolder.transform.eulerAngles.z);
    }

    void ResetFootStepsSound()
    {
        footstepsAreSounding = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();


    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        isRunning = context.ReadValueAsButton();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        isCrouching = context.ReadValueAsButton();
    }

}
