using UnityEngine;
using UnityEngine.UI;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField] private int objectsCollected = 0;
    [SerializeField] private GameObject[] objectsToCollect;
    [SerializeField] private Text collectedText;
    [SerializeField] private GameObject winObject;
    [SerializeField] private Button Exit;
    [SerializeField] private Button MainMenu;
    [SerializeField] private Button Continue;

    private void Start()
    {
        UpdateCollectedText();
        winObject.SetActive(false);
        Exit.onClick.AddListener(OnWinButton1Click);
        MainMenu.onClick.AddListener(OnWinButton2Click);
        Continue.onClick.AddListener(OnWinButton3Click);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ArrayContains(objectsToCollect, other.gameObject))
        {
            objectsCollected++;
            Debug.Log("Collected object " + objectsCollected + " out of " + objectsToCollect.Length);
            UpdateCollectedText();

            // make the collectible object disappear
            other.gameObject.SetActive(false);

            if (objectsCollected >= objectsToCollect.Length)
            {
                Debug.Log("All objects collected!");
                // do something when all objects are collected, such as triggering an event or opening a door

                // activate the win object
                winObject.SetActive(true);

                // activate the cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                // pause the game
                Time.timeScale = 0.0f;
            }
        }
    }

    private void UpdateCollectedText()
    {
        collectedText.text = "Find all the books " + objectsCollected + " / " + objectsToCollect.Length;
    }

    private bool ArrayContains(GameObject[] array, GameObject item)
    {
        foreach (GameObject element in array)
        {
            if (element == item)
            {
                return true;
            }
        }
        return false;
    }

    private void OnWinButton1Click()
    {
        
        // Add your button functionality here
    }

    private void OnWinButton2Click()
    {
        
        // Add your button functionality here
    }

    private void OnWinButton3Click()
    {
        
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
}
