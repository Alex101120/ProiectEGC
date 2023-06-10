using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Reference to the target object to follow
    public float distance = 5.0f; // Distance from the target
    public float height = 2.0f; // Height of the camera above the target
    public float sensitivity = 2.0f; // Mouse sensitivity for rotation
    public float zoomSpeed = 2.0f; // Speed of zooming in and out
    public float minDistance = 2.0f; // Minimum distance from the target
    public float maxDistance = 10.0f; // Maximum distance from the target
float sensX=400;
float sensY=400;
    private float currentDistance; // Current distance from the target
    private float xRotation = 0.0f; // Current X rotation of the camera
    private float yRotation = 0.0f; // Current Y rotation of the camera

    void Start()
    {
        currentDistance = distance;
    }

    void LateUpdate()
    {
        // Check if the target is assigned and handle camera movement
        if (target != null)
        {
            // Zooming in and out with mouse scroll wheel
            float zoomInput = Input.GetAxis("Mouse ScrollWheel");
            currentDistance -= zoomInput * zoomSpeed;
            currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);

            // Rotation with mouse movement
            
            xRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
            yRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;
            yRotation = Mathf.Clamp(yRotation, -90.0f, 90.0f);

            // Calculate camera position and rotation
            Quaternion rotation = Quaternion.Euler(yRotation, xRotation, 0.0f);
            Vector3 position = rotation * new Vector3(0.0f, height, -currentDistance) + target.position;

            // Apply camera position and rotation
            transform.rotation = rotation;
            transform.position = position;

            // Orient the player towards the camera's forward direction
            Vector3 lookDirection = transform.forward;
            lookDirection.y = 0.0f; // Keep the player upright
            target.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}
