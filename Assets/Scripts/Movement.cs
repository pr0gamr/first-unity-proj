using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
// These videos take long to make so I hope this helps you out and if you want to help me out you can by leaving a like and subscribe, thanks!
 
public class Movement : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    [SerializeField] bool cursorLock = true;
    public float mouseSensitivity = 3.5f;
    [SerializeField] float Speed = 6.0f;
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] float gravity = -30f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground; 
    AudioSource audioSource;
    public AudioClip RunningSound;
 
    public float jumpHeight = 6f;
    float velocityY;
    bool isGrounded;
    bool isSprint;
    bool isCrouch;
    bool isOnGround;
    public bool overHead;
 
    float cameraCap;
    Vector2 currentMouseDelta;
    Vector2 currentMouseDeltaVelocity;
    
    CharacterController controller;
    Vector2 currentDir;
    Vector2 currentDirVelocity;
    Vector3 velocity;

    public Camera firstPersonCamera;
    public Camera overheadCamera;
    public GameObject turret;
 
    void Start()
    {
        ShowFirstPersonView();
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
 
    void Update()
    {
        UpdateMove();
        if(Input.GetButtonDown("View") && overHead == false)
        {
            overHead = true;
            ShowOverheadView();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(Input.GetButtonDown("View") && overHead == true)
        {
            overHead = false;
            ShowFirstPersonView();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if(overHead != true)
        {
            UpdateMouse();
            

            Speed = 6.0f;

            if (Input.GetButton("Crouch"))
            {
                Speed = 3.0f;
            }
            else if (Input.GetButton("Sprint"))
            {
                Speed = 9.0f;
            }
        }
        else if(overHead == true)
        {
            if (GetComponent<Movement>().overHead && Input.GetMouseButtonDown(0))
            {
                Ray ray = GetComponent<Movement>().overheadCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(turret, hit.point, Quaternion.Euler(0, 0, 0));
                    Debug.Log(hit.point);
                    Debug.Log("turmnet");
                }
            }
        }
    }
 
    void UpdateMouse()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
 
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
 
        cameraCap -= currentMouseDelta.y * mouseSensitivity;
 
        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);
 
        playerCamera.localEulerAngles = Vector3.right * cameraCap;
 
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }
 
    void UpdateMove()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground);
 
        if (overHead == false)
        {
            Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            targetDir.Normalize();
            currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);
 
        }
        else 
        {
            Vector2 targetDir = new Vector2(0,0);
            targetDir.Normalize();
            currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);
 
        }

        velocityY += gravity * 2f * Time.deltaTime;
 
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * Speed + Vector3.up * velocityY;
 
        controller.Move(velocity * Time.deltaTime);

        if(Input.GetAxisRaw("Horizontal") != 0 && isGrounded == true && overHead == false || Input.GetAxisRaw("Vertical") != 0 && isGrounded == true && overHead == false)
        {
            if(audioSource != null && !audioSource.isPlaying)
            {
                audioSource.clip = RunningSound;
                audioSource.Play();
            }
        }
        else
        {
            if(audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }


        if (isGrounded && Input.GetButtonDown("Jump") && overHead == false)
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("Jump");
        }
 
        if(isGrounded && controller.velocity.y < -1f)
        {
            velocityY = -0f;
        }
    }

    void ShowOverheadView() {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }

    void ShowFirstPersonView() {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }
}