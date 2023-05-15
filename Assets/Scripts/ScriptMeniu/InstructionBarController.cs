using UnityEngine;
using UnityEngine.UI;

public class InstructionBarController : MonoBehaviour
{
    public Canvas canvas;
    private bool canvasShown = false;

    private void Start()
    {
        ShowCanvas();
    }

    private void Update()
    {
        if (canvasShown)
        {
            HideCanvasAfter3Seconds();
        }
    }

    private void ShowCanvas()
    {
        canvas.enabled = true;
        canvasShown = true;
    }

    private void HideCanvasAfter3Seconds()
    {
        Invoke(nameof(HideCanvas), 3f);
    }

    private void HideCanvas()
    {
        canvas.enabled = false;
        canvasShown = false;
    }
}
