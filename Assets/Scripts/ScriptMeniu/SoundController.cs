using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip moveSound;
    public Slider volumeSlider;

    private AudioSource audioSource;
    private bool isMoving;
    private bool canJump = true;

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Set the volume to the initial value of the slider
        audioSource.volume = volumeSlider.value;

        // Add an event listener to update the volume when the slider value changes
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    private void Update()
    {
        // Check for jump input (you can replace this with your own jump detection logic)
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            PlayJumpSound();
            canJump = false;
            Invoke(nameof(ResetJumpCooldown), 3f);
        }

        // Check for movement input (you can replace this with your own movement detection logic)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (!isMoving)
            {
                PlayMoveSound();
                isMoving = true;
            }
        }
        else
        {
            isMoving = false;
            StopMoveSound();
        }
    }

    private void ResetJumpCooldown()
    {
        canJump = true;
    }

    private void PlayJumpSound()
    {
        // Check if the jump sound clip is assigned
        if (jumpSound != null)
        {
            // Play the jump sound using the AudioSource
            audioSource.PlayOneShot(jumpSound);
        }
    }

    private void PlayMoveSound()
    {
        // Check if the move sound clip is assigned
        if (moveSound != null)
        {
            // Play the move sound using the AudioSource
            audioSource.PlayOneShot(moveSound);
        }
    }

    private void UpdateVolume(float value)
    {
        // Update the volume of the AudioSource based on the slider value
        audioSource.volume = value;
    }

    private void StopMoveSound()
    {
        // Stop the move sound
        audioSource.Stop();
    }
}
