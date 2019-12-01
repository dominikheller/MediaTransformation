using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEventCounter : MonoBehaviour
{
    /**
     * Canvas with score.
     **/
    public Text Score;

    /**
     * Current found clues.
     **/
    private int triggerCount = 0;

    /**
     * Maximum clue count.
     **/
    private int maxTriggerCountValue = 3;

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
        bool didHitAndNotTriggeredYet = validateRaycastedObject();

        if (didHitAndNotTriggeredYet == true) {

            triggerCount++;
            setScore();

            if (triggerCount == maxTriggerCountValue)
            {
                Debug.Log("Trigger something!");

                //@todo for example set win text + load new scene
          
                triggerCount = 0;
            }
        }
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

        if (didHit)
        {
            if (clueList.Contains(rhInfo.collider.transform.parent.name))
            {
                return false;
            }

            clueList.Add(rhInfo.collider.transform.parent.name);
            return true;
        }

        return false;
    }
}
