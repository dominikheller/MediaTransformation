using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeLevel : MonoBehaviour
{
    public Animator animator;

    public float fadeTime;
    public string levelToFadeTo;

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }


    public void FadeToScene()
    {
        animator.SetTrigger("FadeOutShort");
        StartCoroutine(delay(fadeTime, levelToFadeTo));
    }

    /**
     * Delays function calls.
     **/
    IEnumerator delay(float time, string levelToFadeTo)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(levelToFadeTo);
    }
}
