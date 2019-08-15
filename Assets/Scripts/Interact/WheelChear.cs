using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChear : MonoBehaviour, IInteractive
{
    public bool isInteractive { get; set; }
    public Types type;
    Player _player;
    public Transform pivot;
    float current;
    public float speedLerpPlayer;
    CameraLook cameraLook;
    public MadLight madLight;
    public enum Types
    {
        Idle, GoSit, Sit, Up
    }
    public void Awake()
    {
        isInteractive = true;
        type = Types.Idle;
    }
    public void Update()
    {
        if (type == Types.GoSit)
        {
            current += Time.deltaTime;
            var dir = pivot.position;
            dir.y = _player.transform.position.y;
            _player.transform.position = Vector3.Lerp(_player.transform.position, dir, current * speedLerpPlayer);
            _player.transform.rotation = Quaternion.Lerp(_player.transform.rotation, pivot.rotation, current * speedLerpPlayer);
            if (Vector3.Distance(_player.transform.position, pivot.position) < 0.5f && Quaternion.Angle(_player.transform.rotation, pivot.transform.rotation) < 0.5f)
            {
                type = Types.Sit;
                Manager.Instance.CameraSteps.Sit();
                madLight.PlayAnimation();
            }
        }
    }
    public void Interact()
    {
        if (isInteractive == true)
        {
            isInteractive = false;
            type = Types.GoSit;
            Debug.Log("Sentante");
            Manager.Instance.DisconnectPlayer();
            cameraLook = Manager.Instance.cameraLook;
            cameraLook.transform.rotation = new Quaternion(0, 0, 0, 0);
            _player = Manager.Instance.GetPlayer;
        }
    }
}
