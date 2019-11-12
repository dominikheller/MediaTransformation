using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTp : MonoBehaviour
{
    Vector3 newPosition = new Vector3(0.0f, 983.06f, 0.0f);
    // Update is called once per frame
    void Update()
    {

        transform.position = newPosition;
    }
}
