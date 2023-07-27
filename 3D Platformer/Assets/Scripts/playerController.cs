using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Player movement speed
    public float rotationSpeed = 100f;  // Player rotation speed
    public float jumpForce = 5f;  // Jump force applied to the player

    private Rigidbody rb;  // Reference to the Rigidbody component
    private bool isGrounded;  // Flag to check if the player is grounded

    private void Start()
    {
        // Get the reference to the Rigidbody component attached to the player object
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Handle jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Apply upward force for jumping
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Check if the player is grounded by detecting collisions with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void FixedUpdate()
    {
        // Get input value for horizontal axis
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Calculate rotation based on input and rotation speed
        Quaternion rotation = Quaternion.Euler(0f, moveHorizontal * rotationSpeed * Time.fixedDeltaTime, 0f);

        // Rotate the player using input
        rb.MoveRotation(rb.rotation * rotation);

        // Get input value for vertical axis
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = transform.forward * moveVertical + transform.right * moveHorizontal;

        // Apply movement to the Rigidbody
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
