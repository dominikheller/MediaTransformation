using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderTeleport : MonoBehaviour
{

    public string folderTag;
    public GameObject folder;

    public void initPlayerPositionChange()
    {
        getFolderTagByRaycasting();
        setFolder();
        setPosition();
    }

    public void defaultPosition()
    {
        gameObject.transform.position = new Vector3(44.01099f, 4.688598f, -1.195291f);
    }

    private void getFolderTagByRaycasting()
    {
        // raycast to screen center
        Ray toCenter = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit rhInfo;
        bool didHit = Physics.Raycast(toCenter, out rhInfo, 500.0f);

        string colliderTag;
        colliderTag = rhInfo.collider.transform.tag;

        if (didHit)
        {
            folderTag = colliderTag;
        }
    }

    private void setFolder()
    {
        folder = GameObject.FindWithTag(folderTag);
    }

    private void setPosition()
    {
        switch (folderTag)
        {
            case "MapPin1":
                gameObject.transform.position = new Vector3(43.934f, 4.845f, -0.677f);
                break;
            case "MapPin2":
                gameObject.transform.position = folder.transform.position;
                break;
            case "MapPin3":
                gameObject.transform.position = folder.transform.position;
                break;
        }
    }
}
