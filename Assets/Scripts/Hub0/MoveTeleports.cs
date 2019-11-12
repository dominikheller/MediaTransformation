using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTeleports : MonoBehaviour
{

    public GameObject teleport;
    
    public void TeleportTeleport()
    {

        teleport.transform.position = new Vector3(transform.position.x, transform.position.y + 983.06f, transform.position.z);
    }
}
