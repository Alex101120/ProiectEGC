using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
   public GameObject pauseMenu; 
    public CursorLockMode cursorMode = CursorLockMode.None; 

    private bool isPaused = false; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused; 

            if (isPaused)
            {
                pauseMenu.SetActive(true); 
                Time.timeScale = 0f; 
                Cursor.lockState = cursorMode; 
                Cursor.visible = true; 
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f; 
                Cursor.lockState = CursorLockMode.Locked; 
                Cursor.visible = false; 
            }
        }
    }
    void PauseGame ()
    {
        Time.timeScale = 0;
    }
void ResumeGame ()
    {
        Time.timeScale = 1;
    }
    
}
