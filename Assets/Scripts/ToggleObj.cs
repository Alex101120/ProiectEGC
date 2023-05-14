using UnityEngine;
using UnityEngine.UI;

public class ToggleObj : MonoBehaviour
{
    public Canvas canvasToToggle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            canvasToToggle.gameObject.SetActive(!canvasToToggle.gameObject.activeSelf);
        }
    }
}
