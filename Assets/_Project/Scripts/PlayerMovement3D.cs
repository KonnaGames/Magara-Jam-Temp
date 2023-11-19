using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerMovement3D : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] Transform floorPoint;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    [SerializeField] bool cursorLock = true;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float Speed = 6.0f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] float gravity = -30f;
    [SerializeField] LayerMask ground;
    [SerializeField] float jumpHeight = 6f;

    

    private float velocityY;
    private bool isGrounded;
    private bool canJump = true;

    private float cameraCap;
    private Vector2 currentMouseDelta;
    private Vector2 currentMouseDeltaVelocity;

    private CharacterController controller;
    private Vector2 currentDir;
    private Vector2 currentDirVelocity;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Debug.Log("Player Start Calisti");
        transform.position = PlayerSpawnManager.instance.SetPlayerPositionBySpawnPoints();

        Invoke(nameof(ActivateController), 1);

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
    }

    private void ActivateController()
    {
        controller.enabled = true;
    }

    void Update()
    {
        if (PlayerHealhtSystem.Instance.GetHealth() > 0)
        {
            UpdateMouse();
            UpdateMove();
        }
    }

    private void UpdateMouse()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraCap -= currentMouseDelta.y * mouseSensitivity;

        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraCap;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    private void UpdateMove()
    {
        isGrounded = Physics.CheckSphere(floorPoint.position, 0.2f, ground);

        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        velocityY += gravity * 2f * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * Speed + Vector3.up * velocityY;
        controller.Move(velocity * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump") && canJump)
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
            canJump = false;
            StartCoroutine(JumpTimer());
        }

        if (isGrounded! && controller.velocity.y < -1f)
        {
            velocityY = -8f;
        }
    }
    private IEnumerator JumpTimer()
    {
        yield return new WaitForSeconds(0.8f);

        canJump = true;
    }
}
