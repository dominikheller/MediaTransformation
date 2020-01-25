using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantSceneChange : MonoBehaviour
{
    public void ChangeSceneInstantly(string sceneNameX)
    {
        SceneManager.LoadScene(sceneNameX);
    }
}