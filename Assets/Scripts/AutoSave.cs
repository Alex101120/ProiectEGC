using UnityEngine;

public class AutoSave : MonoBehaviour
{
    public float saveInterval = 300f; // 5 minutes
    private float saveTimer;

    private Vector3 lastSavedPosition;

    private void Start()
    {
        // Load the last saved position if it exists
        if(PlayerPrefs.HasKey("lastSavedPosX") && PlayerPrefs.HasKey("lastSavedPosY") && PlayerPrefs.HasKey("lastSavedPosZ"))
        {
            lastSavedPosition = new Vector3(PlayerPrefs.GetFloat("lastSavedPosX"), PlayerPrefs.GetFloat("lastSavedPosY"), PlayerPrefs.GetFloat("lastSavedPosZ"));
            transform.position = lastSavedPosition;
        }

        // Start the save timer
        saveTimer = saveInterval;
    }

    private void Update()
    {
        // Update the save timer
        saveTimer -= Time.deltaTime;

        // Save the player's position every 5 minutes
        if (saveTimer <= 0f)
        {
            SavePlayerPosition();
            saveTimer = saveInterval;
        }
    }

    private void OnApplicationQuit()
    {
        // Save the player's position when the game is closed
        SavePlayerPosition();
    }

    private void SavePlayerPosition()
    {
        // Save the player's position using PlayerPrefs
        PlayerPrefs.SetFloat("lastSavedPosX", transform.position.x);
        PlayerPrefs.SetFloat("lastSavedPosY", transform.position.y);
        PlayerPrefs.SetFloat("lastSavedPosZ", transform.position.z);

        // Save the PlayerPrefs data to disk
        PlayerPrefs.Save();

        Debug.Log("Player position saved.");
    }
}
