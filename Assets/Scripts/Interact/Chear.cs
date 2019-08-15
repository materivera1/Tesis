using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chear : MonoBehaviour, IInteractive
{
    FSM<string> fsm;
    public float current;
    public Player _player;
    public Transform pivot;
    public float speedLerpPlayer;

    public bool isInteractive { get; set; }

    public void Awake()
    {
        var Idle = new FSMState<string>("Idle");
        var Sit = new FSMState<string>("Sit");
        Idle.AddTransition(Sit);
        Sit.AddTransition(Idle);
        Sit.Update += () =>
        {
            Debug.Log("asdas");
            current += Time.deltaTime;
            var dir = pivot.position;
            dir.y = _player.transform.position.y;
            _player.transform.position = Vector3.Lerp(_player.transform.position, dir, current * speedLerpPlayer);
            _player.transform.rotation = Quaternion.Lerp(_player.transform.rotation, pivot.rotation, current * speedLerpPlayer);
            if (Vector3.Distance(_player.transform.position, pivot.position) < 0.5f && Quaternion.Angle(_player.transform.rotation, pivot.transform.rotation) < 0.5f)
            {
                fsm.Transition("Sit");
            }
        };
        Sit.Exit += () => { Manager.Instance.CameraSteps.Sit(); };
        fsm = new FSM<string>(Idle);
    }
    public void Update()
    {
        fsm.Update();
    }

    public void Interact()
    {
        if (isInteractive)
        {
            _player = Manager.Instance.player;
            isInteractive = false;
            fsm.Transition("Sit");
        }
    }
}
