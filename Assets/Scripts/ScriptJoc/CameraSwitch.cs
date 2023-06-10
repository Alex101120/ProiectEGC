using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject firstPersonCamera; // Reference to the first-person camera
    public GameObject thirdPersonCamera; // Reference to the third-person camera
    public Canvas canvas; // Reference to the canvas to toggle

    private bool isThirdPerson = false; // Flag to track the camera mode

    private void Start()
    {
        // Initially disable the third-person camera and canvas
        thirdPersonCamera.SetActive(false);
        canvas.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isThirdPerson = !isThirdPerson; // Toggle the camera mode

            // Enable or disable the cameras based on the camera mode
            firstPersonCamera.SetActive(!isThirdPerson);
            thirdPersonCamera.SetActive(isThirdPerson);

            // Toggle the canvas based on the camera mode
            canvas.enabled = !isThirdPerson;
        }
    }

    private void LateUpdate()
    {
        if (isThirdPerson)
        {
            // Match the rotation of the first-person camera with the third-person camera rotation
            thirdPersonCamera.transform.rotation = firstPersonCamera.transform.rotation;
        }
    }
}
