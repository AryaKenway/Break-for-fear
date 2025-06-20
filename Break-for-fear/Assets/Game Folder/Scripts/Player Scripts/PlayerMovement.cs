
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSensitivity = 2f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;
    public float verticalVelocity;
    public Transform cameraTransform;

    //public Vector3 defaultCameraPosition = new Vector3(0f, 1.6f, 0f);
    //public Vector3 crouchCameraPosition = new Vector3(0f, 1.0f, 0f);

    public CharacterController controller;
    private Vector3 velocity;
    private float xRotation = 0f;
    private float ySpeed;
    public float cameraSmoothSpeed = 15f;

    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            moveSpeed = value;
        }
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // This is to remove the cursor from game screen 
    }

    void Update()
    {
        HandleLook();
        HandleMovement();
       // AdjustCameraHeight();
    }

    void HandleLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        xRotation = xRotation - mouseY; // Unity's rotation works opposite. So if you look up it gives -ve value but it should be +ve so we are subtracting to give correct output
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // This prevents from looking beyond 90 degrees, so you cant turn your head 360 degrees

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Quaternion.Euler converts angles into rotation for game
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime); // adding moveSpeed to manipulate its value

    }
    //void AdjustCameraHeight()
    //{
    //    float x = Input.GetAxis("Horizontal");
    //    float z = Input.GetAxis("Vertical");

    //    bool isMoving = x != 0 || z != 0;
    //    Vector3 targetPosition = isMoving ? crouchCameraPosition : defaultCameraPosition;

    //    cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, targetPosition, Time.deltaTime * cameraSmoothSpeed);
    //}
}