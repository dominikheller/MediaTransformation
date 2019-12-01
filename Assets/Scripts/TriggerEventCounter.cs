using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEventCounter : MonoBehaviour
{
    public Text Score;

    public int triggerCount = 0;

    private int maxTriggerCountValue = 2;


    private void Start()
    {
        setScore();
    }


    public void onPointerClick()
    {
        triggerCount++;
        setScore();

        if (triggerCount == maxTriggerCountValue)
        {
            Debug.Log("Trigger something!");

            //@todo for example set win text + load new scene

            triggerCount = 0;
        }
    }


    private void setScore()
    {
        Score.text = triggerCount.ToString() + "/" + maxTriggerCountValue.ToString();
    }
}
