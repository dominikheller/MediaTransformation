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
     * Canvas ui slider.
     **/
    public Slider slider;

    /**
     * Current found clues.
     **/
    public int triggerCount = 0;

    /**
    * Triggered clue index;
    **/
    public int clueIndex;

    /**
     * Maximum clue count.
     **/
    public int maxTriggerCountValue;

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
                GameObject staticAudioSource = GameObject.FindWithTag("StaticAudioSource");
                staticAudioSource.GetComponent<AudioController>().startAudio();
                StartCoroutine(delay(5));

                triggerCount = 0;
            }
        }
    }

    
    /**
     * Delays function calls.
     **/
    IEnumerator delay(float time)
    {
        GameObject globalData = GameObject.FindWithTag("BasicGVR");
        GameObject fadeLevel = GameObject.FindWithTag("FadeLevel");
        fadeLevel.GetComponent<FadeLevel>().FadeToLevel();

        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(globalData.GetComponent<LevelController>().levelToFadeTo);
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
        slider.value = triggerCount;
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

    /**
    * Gets clue tag by raycasting.
    **/
    public void getClueTagByRaycasting()
    {
        // raycast to screen center
        Ray toCenter = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit rhInfo;
        bool didHit = Physics.Raycast(toCenter, out rhInfo, 500.0f);

        string colliderTag;
        colliderTag = rhInfo.collider.transform.tag;
        
        if (didHit)
        {
            switch (colliderTag)
            {
                case "1":
                    clueIndex = 1;
                    break;
                case "2":
                    clueIndex = 2;
                    break;
                case "3":
                    clueIndex = 3;
                    break;
                case "4":
                    clueIndex = 4;
                    break;
                case "5":
                    clueIndex = 5;
                    break;
                case "6":
                    clueIndex = 6;
                    break;
            }
        }
    }
}
