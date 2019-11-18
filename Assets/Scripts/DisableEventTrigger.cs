using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableEventTrigger : MonoBehaviour
{
    public void disableEventTrigger()
    {
        gameObject.GetComponent<EventTrigger>().enabled = false;
    }
}
