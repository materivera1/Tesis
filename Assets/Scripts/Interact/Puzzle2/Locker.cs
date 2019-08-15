using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour, IInteractive
{
    public Animator anim;
    public bool isInteractive { get; set; }
    public enum States {Closed, Opened }
    public States state;
    public bool fromPuzzle;
    public bool inter;
    Locker[] locks;
    void Awake()
    {
        isInteractive = true;
        state = States.Closed;
        //anim.Play("IdleLocker");
        inter = isInteractive;
        locks = FindObjectsOfType<Locker>();
        Debug.Log(locks.Length);
    }
    public void Interact()
    {
        if (state == States.Closed)
        {
            OpenLocker();
        }
        else if (state == States.Opened)
        {
            CloseLocker();            
        }
    }
    public void CloseLocker()
    {
        if (isInteractive)
        {
            anim.Play("CloseLocker");
        }
    }

    public void OpenLocker()
    {
        if (isInteractive)
        {
            anim.Play("OpenLocker");
        }
    }
    void NonInteractive()
    {
        foreach (var item in locks)
        {
            item.isInteractive = false;
        }
    }
    void OpenedState()
    {
        state = States.Opened;
        foreach (var item in locks)
        {
            item.isInteractive = true;
        }
    }
    void ClosedState()
    {
        state = States.Closed;
        foreach (var item in locks)
        {
            item.isInteractive = true;
        }
    }
}
