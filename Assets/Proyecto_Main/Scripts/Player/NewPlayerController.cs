using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using FMODUnity;
using FMOD.Studio;

public class NewPlayerController : MonoBehaviour
{
    public GameObject camHolder;
    private CharacterController characterController;
    public PlayerInput playerInput;
    private Transform playerTransform;
    public Animator playerAnim;

    //public AudioSource playerSteps;
    //public AudioClip metallicSteps_Walk;
    //public AudioClip normalSteps_Walk;
    //public AudioClip metallicSteps_Run;
    //public AudioClip normalSteps_Run;
    //private bool isOnMetallic, runAudioCheck, walkAudioCheck;

    private Vector2 look, input;

    //public AudioSource playerSteps;
    //public AudioClip metallicSteps_Walk;
    //public AudioClip normalSteps_Walk;
    //public AudioClip metallicSteps_Run;
    //public AudioClip normalSteps_Run;
    private bool isRunning, isCrouching, isWalking;
    private Vector3 direction;
    
    public float sensitivity;
    private float lookRotation;
    private float velocity;
    private float gravity = -9.81f;

    [SerializeField] private float currentSpeed, walkSpeed, crouchSpeed, runSpeed;
    [SerializeField] private float gravityMultiplier = 0.75f;

    private bool isOnMetallic;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerTransform = transform;
    }

    void Update()
    {
        if (input.x != 0 || input.y != 0)
        {
            isWalking = true;
        }

        else
        {
            isWalking = false;
        }

        if (isCrouching)
        {
            currentSpeed = crouchSpeed;
            isRunning = false;
            //playerSteps.Stop();
        }

        if (isRunning)
        {
            currentSpeed = runSpeed;
        }
        
        if (!isRunning && !isCrouching)
        {
            currentSpeed = walkSpeed;
        }

        if (!isRunning && !isCrouching && input == Vector2.zero)
        {
            playerAnim.SetBool("isCrouching", false);
            playerAnim.SetBool("isRunning", false);
            playerAnim.SetBool("isWalking", false);
        }

        playerAnim.SetBool("isCrouching", isCrouching);
        playerAnim.SetBool("isRunning", isRunning);
        playerAnim.SetBool("isWalking", isWalking);

        ChangeSteps();
    }
    private void FixedUpdate()
    {
        ApplyMovement();
        ApplyGravity();
    }

    void LateUpdate()
    {
        Look();
    }

    private void ApplyMovement()
    {
        characterController.Move(playerTransform.TransformDirection(direction) * currentSpeed * Time.deltaTime);
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

    private void ApplyGravity()
    {
        if (IsGrounded() && velocity < 0.0f)
        {
            velocity = -1.0f;
        }
        else
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;
        }

        direction.y = velocity;
    }

    private bool IsGrounded() => characterController.isGrounded;

    public void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
        direction = new Vector3(input.x, 0.0f, input.y);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MetallicSteps"))
        {
            isOnMetallic = true;
            //ChangeSteps();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MetallicSteps"))
        {
            isOnMetallic = false;
            //ChangeSteps();
        }
    }

    private void ChangeSteps()
    {
        if (isOnMetallic)
            AudioManager.instance.SetFMODLabeledParameter("footstepsSounds", "footsteps_metal", GetComponent<StudioEventEmitter>().EventInstance);
        else
        {
            if (isRunning)
                AudioManager.instance.SetFMODLabeledParameter("footstepsSounds", "footsteps_asphalt_run", GetComponent<StudioEventEmitter>().EventInstance);
            else
                AudioManager.instance.SetFMODLabeledParameter("footstepsSounds", "footsteps_asphalt", GetComponent<StudioEventEmitter>().EventInstance);
        }
    }
}
