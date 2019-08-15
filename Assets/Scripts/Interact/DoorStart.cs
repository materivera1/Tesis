using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStart : Door
{
    bool isStart = false;
    public GameObject initRoom;
    public override void ClosedDoor()
    {
        base.ClosedDoor();
        if (!isStart)
        {
            isStart = true;
            return;
        }
        else
        {
            initRoom.SetActive(false);
            return;
        }
    }
}