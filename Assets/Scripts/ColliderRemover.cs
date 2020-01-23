using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRemover : MonoBehaviour
{
    public void removeChildrenColliders()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<BoxCollider>().enabled = false;
        }
    }
}

