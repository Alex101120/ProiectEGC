using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScript : MonoBehaviour
{
   public GameObject LoadingScreen;
   public Image LoadingBarFill;

   public void LoadScene(int SceneID)
   {
StartCoroutine(LoadSceneAsync(SceneID));
   }
   IEnumerator LoadSceneAsync(int SceneID)
   {
    AsyncOperation operation = SceneManager.LoadSceneAsync(SceneID);
    LoadingScreen.SetActive(true);
    while(!operation.isDone)
    {
        float progressValue = Mathf.Clamp01(operation.progress/0.9f);
        LoadingBarFill.fillAmount = progressValue;
        yield return null;
    }
   }

}
