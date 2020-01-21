using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour
{
    public void ChangeScene(string sceneName) {
        StartCoroutine(delay(5, sceneName));
    }

    /**
     * Delays function calls.
     **/
    IEnumerator delay(float time, string sceneName)
    {
        GameObject fadeLevel = GameObject.FindWithTag("FadeLevel");
        fadeLevel.GetComponent<FadeLevel>().FadeToLevel();

        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(sceneName);
    }
}
