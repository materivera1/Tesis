using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Door door;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        door.OpenDoor();
    }
    public void Play()
    {
        Manager.Instance.CameraSteps.Starting();
        Manager.Instance.cameraLook.LockCursor();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        door.ClosedDoor();
    }
    public void HideObj(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

}
