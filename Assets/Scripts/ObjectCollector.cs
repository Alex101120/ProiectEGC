using UnityEngine;
using UnityEngine.UI;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField] private int objectsCollected = 0;
    [SerializeField] private GameObject[] objectsToCollect;
    [SerializeField] private Text collectedText;
    [SerializeField] private Canvas winCanvas;

    private void Start()
    {
        UpdateCollectedText();
        winCanvas.enabled = false;
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

                // activate the win canvas
                winCanvas.enabled = true;

                // activate the cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                // pause the game
                Time.timeScale = 0.0f;
            }
        }
    }

    private void Update()
    {
        // hide the cursor when the player clicks the mouse
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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
}
