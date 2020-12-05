using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

    #region InputActionReference
    [SerializeField] private InputActionReference movementControl;
    [SerializeField] private InputActionReference jumpControl;
    [SerializeField] private InputActionReference crouchControl;
    [SerializeField] private InputActionReference interactControl;
    [SerializeField] private InputActionReference openMenu;
    #endregion

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f; //same as unity physics value

    [SerializeField] private float rotationSpeed = 4f;

    private CharacterController controller;    
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Transform cam;
    public GameObject cinemachineLock;
    public CinemachineVirtualCamera directObjCam;
    private CinemachineVirtualCamera playerLockCam;

    private Animator anim;

    public bool isLocking = false;
    bool onMenu = false;  //move to state

    #region ActionAnnouncer
    public static event Action<PlayerMovement> OnOpenMenu; 
    public static event Action<PlayerMovement> OnInteract;
    #endregion

    #region PlayerState

    public enum PlayerState //Change the movement handling to state pattern later
    {
        Talking,
        OnGround,
        OnAir,
        OpeningMenu,

    }

    private PlayerState playerState = PlayerState.OnGround;
    #endregion

    #region CameraMode
    public enum CameraMode
    {
        Free,
        LockOn,
        Cutscene,
        OnObject
    }

    private CameraMode cameraMode = CameraMode.Free;
    #endregion

    private void OnEnable()
    {
        movementControl.action.Enable(); //Enable (and disable) these reference action
        jumpControl.action.Enable();     //Utilize this to activate/deactivate player control
        crouchControl.action.Enable();   //Instead of SetActive the component
        openMenu.action.Enable();
        interactControl.action.Enable();
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
        crouchControl.action.Disable();
        openMenu.action.Disable();
        interactControl.action.Disable();
    }

    private void DisablingMovement()  //when opening UI
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
        crouchControl.action.Disable();
    }

    private void EnablingMovement()
    {
        movementControl.action.Enable(); 
        jumpControl.action.Enable();    
        crouchControl.action.Enable();
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        cam = Camera.main.transform;
        playerLockCam = cinemachineLock.GetComponent<CinemachineVirtualCamera>();
        InventoryUI.OnAssembling += AssemblingControl;
    }

    private void CameraLock()
    {        
        if(!isLocking)
        {
            isLocking = true;
            playerLockCam.m_Priority = 11;
        }
        else
        {
            isLocking = false;
            playerLockCam.m_Priority = 0;
        }

    }

    private void AssemblingControl(InventoryUI ui)
    {
        directObjCam.m_Priority = 11;
        
    }

    void Update()
    {
        
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        

        groundedPlayer = controller.isGrounded;
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        //if !isGrounded, don't read
        Vector2 movement = movementControl.action.ReadValue<Vector2>();

        #region Movement Animation
        //Animator handler
        if (movement != Vector2.zero)
        {
            anim.SetBool("run", true);
        }
        if(movement == Vector2.zero)
        {
            anim.SetBool("run", false);
        }
        #endregion

        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cam.forward * move.z + cam.right * move.x;
                    
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);


        #region FaceDirection
        
        //Player face direction related to camera (Free Move Camera)
        
        if (movement != Vector2.zero && cameraMode == CameraMode.Free) 
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }

        if (movement != Vector2.zero && cameraMode == CameraMode.LockOn)
        {
            float targetAngle = cam.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }

        #endregion

        // Changes the height position of the player..
        if (jumpControl.action.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(crouchControl.action.triggered)
        {
            /*
            if (cameraMode != CameraMode.Free)
                cameraMode = CameraMode.LockOn;
            else
            {
                cameraMode = CameraMode.Free;
            }
            */

            CameraLock();
            Debug.Log("CROUCH");
        }


        if (openMenu.action.triggered)
        {
            OnOpenMenu?.Invoke(this);
            if(onMenu)
            {
                EnablingMovement();
            }
            else 
            {
                DisablingMovement();
                onMenu = false;
            }
        }

        if(interactControl.action.triggered)
        {
            OnInteract?.Invoke(this);
        }
        
    }
}
