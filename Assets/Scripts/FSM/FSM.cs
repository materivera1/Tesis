using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T>
{
    FSMState<T> current;
    public FSM(FSMState<T> initState)
    {
        current = initState;
        current.Enter();
    }
    public void Update()
    {
        current.Update();
    }
    public void Transition(T key)
    {
        var nextState = current.GetState(key);
        if (nextState != null)
        {
            current.Exit();
            current = nextState;
            current.Enter();
        }
    }
}
