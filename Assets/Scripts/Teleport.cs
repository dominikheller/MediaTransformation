using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject player;

    public void TeleportPlayer()
    {
        player.transform.position = new Vector3(transform.position.x, transform.position.y + 1.35f, transform.position.z);
    }

}
