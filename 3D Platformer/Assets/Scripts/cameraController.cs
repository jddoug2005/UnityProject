using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target;  // Reference to the player's transform
    public float distance = 5f;  // Distance between the camera and the player
    public float rotationSpeed = 100f;  // Camera rotation speed

    private float currentAngle = 0f;  // Current angle of rotation around the player

    private void LateUpdate()
    {
        // Check if the player has pressed the left arrow key
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentAngle -= rotationSpeed * Time.deltaTime;
        }
        // Check if the player has pressed the right arrow key
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            currentAngle += rotationSpeed * Time.deltaTime;
        }

        // Calculate the new position and rotation of the camera
        Quaternion rotation = Quaternion.Euler(0f, currentAngle, 0f);
        Vector3 newPosition = target.position + rotation * new Vector3(0f, 0f, -distance);

        // Apply the new position and rotation to the camera
        transform.position = newPosition;
        transform.LookAt(target);

        // Rotate the target on the y-axis based on the camera's rotation
        target.rotation = Quaternion.Euler(0f, currentAngle, 0f);
    }
}


