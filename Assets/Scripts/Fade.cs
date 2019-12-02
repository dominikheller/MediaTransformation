using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Animator animator;


    /**
     * Triggers fade out animation.
     **/
    public void fadeOut()
    {
        if (animator != null && animator.gameObject.activeSelf)
        {
            animator.SetTrigger("FadeOut");
        }
    }
}
