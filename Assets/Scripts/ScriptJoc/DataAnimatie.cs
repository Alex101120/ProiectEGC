using UnityEngine;

public class DataAnimatie : MonoBehaviour
{
    public GameObject Player; // Reference to the game object with the PlayerMovement component
    private PlayerMovement playerMovement; // Reference to the PlayerMovement component
    private Animator animator; // Reference to the Animator component

    private void Start()
    {
        // Check if the playerObject is assigned
        if (Player != null)
        {
            // Get the PlayerMovement component from the playerObject
            playerMovement = Player.GetComponent<PlayerMovement>();
        }
        else
        {
            Debug.LogError("Player object reference is not assigned to DataAnimatie script.");
        }

        // Get the Animator component attached to the same game object
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Access and collect data from PlayerMovement
        if (playerMovement != null)
        {
            float speed = playerMovement.text_speed;

            // Update the "Speed" parameter of the Animator
            animator.SetFloat("Speed", speed);

            // Process or store the collected data as needed
            // ...
        }
    }
}
