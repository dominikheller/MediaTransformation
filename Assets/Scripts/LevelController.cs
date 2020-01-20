using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public List<GameObject> openFolders;

    public List<string> listOfScenes;
    public List<string> listOfMapPins;

    private string currentSceneName;

    void Start()
    {
        listOfScenes = GlobalDataController.Instance.listOfScenes;
        listOfMapPins = GlobalDataController.Instance.listOfMapPins;

        currentSceneName = SceneManager.GetActiveScene().name;

        if (!listOfScenes.Contains(currentSceneName))
        {
            listOfScenes.Add(currentSceneName);
        }

        saveListOfFinishedLevels();
        destroyTriggeredMapPins();
    }

    public void addMapPinToList()
    {
        string mapPinTag = getMapPinTagByRaycasting();

        if (mapPinTag != "")
        {
            if (!listOfMapPins.Contains(mapPinTag))
            {
                listOfMapPins.Add(mapPinTag);
            }
        }

        saveListOfTriggeredMapPins();
    }

   private string getMapPinTagByRaycasting()
    {
        // raycast to screen center
        Ray toCenter = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit rhInfo;
        bool didHit = Physics.Raycast(toCenter, out rhInfo, 500.0f);

        string colliderName;
        colliderName = rhInfo.collider.transform.tag;

        if (didHit)
        {
            return colliderName;
        }

        return "";
    }

    private void destroyTriggeredMapPins()
    {
        foreach (string mapPinTag in listOfMapPins)
        {
            GameObject mapPin = GameObject.FindWithTag(mapPinTag);
            if(mapPin != null)
            {
                Destroy(mapPin);
            }
        }
    }

    private void saveListOfFinishedLevels()
    {
        GlobalDataController.Instance.listOfScenes = listOfScenes;
    }

    private void saveListOfTriggeredMapPins()
    {
        GlobalDataController.Instance.listOfMapPins = listOfMapPins;
    }
}
