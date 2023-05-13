using UnityEngine;
using UnityEngine.UI;

public class InstructionBarController : MonoBehaviour
{
    public Button okButton;
    public GameObject instructionBar;
    public float delayTime = 3f;

    private void Start()
    {
   
        bool instructionBarShownBefore = PlayerPrefs.GetInt("instructionBarShownBefore", 0) == 1;
        if (!instructionBarShownBefore)
        {
            instructionBar.SetActive(true);
            Invoke(nameof(HideInstructionBar), delayTime);
            okButton.onClick.AddListener(HideInstructionBar);
            PlayerPrefs.SetInt("instructionBarShownBefore", 1);
        }
        else
        {
            instructionBar.SetActive(false);
        }
    }

    private void HideInstructionBar()
    {
        instructionBar.SetActive(false);
    }
}
