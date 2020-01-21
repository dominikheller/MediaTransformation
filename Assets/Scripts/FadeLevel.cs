using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLevel : MonoBehaviour
{
    public Animator animator;

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }
}
