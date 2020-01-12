using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalDataController : MonoBehaviour
{
    public static GlobalDataController Instance;

    public List<string> listOfScenes;
    public List<string> listOfMapPins;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
