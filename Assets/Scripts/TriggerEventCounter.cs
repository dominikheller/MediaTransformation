using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventCounter : MonoBehaviour
{
    public LevelChanger levelChanger;

    public int triggerCount = 0;

    private int maxTriggerCountValue = 5;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerCount++;

        if (triggerCount == maxTriggerCountValue)
        {
            Debug.Log("Trigger something!");

            // for example the level changer
            // levelChanger.FadeToLevel("levelName");

            triggerCount = 0;
        }
    }
}
