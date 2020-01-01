﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject player;

    public void TeleportPlayer()
    {
        player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
    }

}
