using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractive
{
    public Animator anim;
    float initRotationY;
    Vector3 _triggerPosClose;
    public float triggerdistanceDoor;
    public float distanceToClosed;
    Transform _player;
    public States state;
    public bool isInteractive { get; set; }
    public GameObject[] hideObj;

    public enum States
    {
        Idle, Open, Closed
    }
    private void Awake()
    {
        state = States.Idle;
        _triggerPosClose = transform.position + transform.up * triggerdistanceDoor;
        isInteractive = true;
    }
    public void Update()
    {
        if (state == States.Open)
        {
            if (Vector3.Distance(_triggerPosClose, _player.position) < distanceToClosed)
            {
                ClosedDoor();
                state = States.Closed;
            }
        }
    }
    public virtual void OpenDoor()
    {
        anim.Play("Open");
        _player = GameObject.FindObjectOfType<Player>().transform;
    }
    public virtual void ClosedDoor()
    {
        if (hideObj.Length > 0)
        {
            foreach (var item in hideObj)
            {
                item.SetActive(false);
            }
        }
        anim.Play("Closed");
    }
    public void Interact()
    {
        if (isInteractive && state == States.Idle)
        {
            OpenDoor();
            isInteractive = false;
            state = States.Open;
        }
    }
    public virtual void ResetDoor()
    {
        isInteractive = true;
        anim.Play("Idle");
        state = States.Idle;
    }
    public void ChangeDistanceClose(float dis)
    {
        triggerdistanceDoor = dis;
        _triggerPosClose = transform.position + transform.up * triggerdistanceDoor;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_triggerPosClose, distanceToClosed);
    }
}
