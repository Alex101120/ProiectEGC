using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    
float sensX= 400;
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;

        Vector3 currentRotation = transform.eulerAngles;
        float newRotationY = currentRotation.y + mouseX;

        transform.rotation = Quaternion.Euler(currentRotation.x, newRotationY, currentRotation.z);
    }
}
