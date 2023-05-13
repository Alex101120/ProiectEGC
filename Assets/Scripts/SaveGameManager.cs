using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
    private float saveInterval = 300f; // 5 minutes in seconds

    private void Start()
    {
        StartCoroutine(SavePlayerPosition());
    }

    private IEnumerator SavePlayerPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(saveInterval);

            // save player position to PlayerPrefs
            PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ", transform.position.z);
            PlayerPrefs.Save();
        }
    }
}
