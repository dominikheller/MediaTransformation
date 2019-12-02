using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerEventCounter : MonoBehaviour
{
    public Animator animator;

    /**
     * Canvas with score.
     **/
    public Text Score;

    /**
     * Current found clues.
     **/
    public int triggerCount = 0;

    /**
     * Maximum clue count.
     **/
    public int maxTriggerCountValue = 6;

    /**
     * Clue list (is needed to check if the current raycasted clue was already triggered).
     **/
    private List<string> clueList;


    /**
     * Inits variables and functions.
     **/
    private void Start()
    {
        clueList = new List<string>();
        setScore();
    }


    /**
     * Increases trigger count.
     **/
    public void onPointerClick()
    {
        bool valid = validateRaycastedObject();

        if (valid == true) {

            increaseTriggerCount();
            setScore();

            if (triggerCount == maxTriggerCountValue)
            {
                gameObject.GetComponent<AudioController>().startAudio();

                //@todo fix animation
                animator.SetTrigger("FadeOut");
                triggerCount = 0;
            }
        }
    }


    /**
     * Increases trigger count variable.
     **/
    private void increaseTriggerCount()
    {
        triggerCount++;
    }


    /**
     * Sets score.
     **/
    private void setScore()
    {
        Score.text = triggerCount.ToString() + "/" + maxTriggerCountValue.ToString();
    }


    /**
     * Validates if raycasted object was already triggered.
     **/
    private bool validateRaycastedObject()
    {
        // raycast to screen center
        Ray toCenter = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit rhInfo;
        bool didHit = Physics.Raycast(toCenter, out rhInfo, 500.0f);

        string colliderName;
        if (rhInfo.collider.transform.parent != null)
        {
            colliderName = rhInfo.collider.transform.parent.name;
        } else
        {
            colliderName = rhInfo.collider.transform.name;
        }

        if (didHit)
        {
            if (clueList.Contains(colliderName))
            {
                return false;
            }

            clueList.Add(colliderName);
            return true;
        }

        return false;
    }
}
