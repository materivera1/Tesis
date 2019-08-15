using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; }
    public Player player;
    public PlayerController playerController;
    public CameraLook cameraLook;
    public CameraInteractive cameraInteractive;
    public CameraSteps CameraSteps;
    public Rigidbody rb;

    List<int> list;
    int num;
    public void Awake()
    {
        Instance = this;
    }
    public void DisconnectPlayer()
    {
        // player.enabled = false;
        playerController.enabled = false;
        cameraLook.enabled = false;
        CameraSteps.enabled = false;
        //rb.Sleep();
    }
    public void DisconnectPlayer(bool resetLook)
    {
        if(resetLook)
            cameraLook.ResetRot();
    }
    public void DisconnectPlayer(bool resetLook,bool resetIdle)
    {
        DisconnectPlayer(true);
        if (resetIdle)
            CameraSteps.Idle();
    }
    public void ConnectPlayer()
    {
        //player.enabled = true;
        playerController.enabled = true;
        cameraLook.enabled = true;
        CameraSteps.enabled = true;
        // rb.WakeUp();
    }
    public void ConnectPlayer(bool resetLook)
    {
        //player.enabled = true;
        ConnectPlayer();
        if (resetLook)
            cameraLook.ResetRot();
  

        // rb.WakeUp();
    }
    public Player GetPlayer
    {
        get
        {
            return player;
        }
    }
}
