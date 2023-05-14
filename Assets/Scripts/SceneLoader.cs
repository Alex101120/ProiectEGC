using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string Joc)
    {
        SceneManager.LoadScene(Joc);
        
    }
   
}