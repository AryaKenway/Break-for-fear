using UnityEngine;
public class DoubleJump : MonoBehaviour
{
    public CharacterController controller;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;
    private bool isGrounded;
    public bool IsGrounded // this makes the property readable, but cannot be modified
    {
        get
        {
            return isGrounded;
        }
    }

    private Vector3 velocity;
    private int jumpCount = 0;
    private int maxJumps = 2;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // Ground check
        if (isGrounded && velocity.y < 0) // Velocity y is up and down ( Vertical movement)
        {
            velocity.y = -2f;
            jumpCount = 0;
        }

        // Jump input
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            Debug.Log("Jump Pressed!");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // --> Formula for Jump = v = √(2 * g * h) where v = initial jump velocity, g = gravity and h = how high you want to jump  
            jumpCount++;
        }

        // Apply gravity
        velocity.y = velocity.y + gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
