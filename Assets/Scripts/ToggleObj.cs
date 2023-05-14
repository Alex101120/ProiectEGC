using UnityEngine;
using UnityEngine.UI;

public class ToggleObj : MonoBehaviour
{
    public Canvas canvasToToggle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            canvasToToggle.gameObject.SetActive(!canvasToToggle.gameObject.activeSelf);
        }
    }
}
