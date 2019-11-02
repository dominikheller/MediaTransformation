using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTitleAnimation : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;

    public void NextAnim() {

        myAnimationController.SetInteger("animInt", myAnimationController.GetInteger("animInt") + 1);
    
    }
}
