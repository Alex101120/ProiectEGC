using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public float teleportY = -50f;
    public float teleportX = 0f;
    public float teleportZ = 0f;

    private void Update()
    {
        float yPosition = transform.position.y;

        if (yPosition < teleportY)
        {
            Teleport();
        }
    }

    private void Teleport()
    {
        Vector3 teleportPosition = new Vector3(940f, 20f, 940f);
        transform.position = teleportPosition;
    }
}
