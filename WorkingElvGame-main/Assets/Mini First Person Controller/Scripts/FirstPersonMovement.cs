using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 5;
    public bool IsPlayer1;
    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    private Rigidbody rigidbody;
    private bool isGrounded;

    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the player is on the ground (to prevent double jump).
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);
        if (IsPlayer1)
        {
            // Handle jump input.
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                Jump();
            }
        }
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);
        
        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }
        if (IsPlayer1)
        {
            // Get targetVelocity from input (only left and right movement).
            float moveInput = Input.GetAxis("Horizontal"); // Left/Right movement
            Vector3 targetVelocity = transform.right * moveInput * targetMovingSpeed;
            targetVelocity.y = rigidbody.velocity.y; // Preserve vertical velocity (for jumping and gravity)
                                                     // Apply movement.
            rigidbody.velocity = targetVelocity;
        }
        else
        {
            // Get targetVelocity from input (only left and right movement).
            float moveInput = Input.GetAxis("Horizontal2"); // Left/Right movement
            Vector3 targetVelocity = transform.right * moveInput * targetMovingSpeed;
            targetVelocity.y = rigidbody.velocity.y; // Preserve vertical velocity (for jumping and gravity)
                                                     // Apply movement.
            rigidbody.velocity = targetVelocity;
        }
    }

    void Jump()
    {
        // Apply jump force if grounded.
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpForce, rigidbody.velocity.z);
    }
}