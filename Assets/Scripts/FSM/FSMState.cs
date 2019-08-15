using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FSMState<T>
{
    public T identity;
    public Action Enter = delegate { };
    public Action Update = delegate { };
    public Action Exit = delegate { };
    private Dictionary<T, FSMState<T>> dic = new Dictionary<T, FSMState<T>>();
    public FSMState(T nameState)
    {
        identity = nameState;
    }
    public void AddTransition(FSMState<T> value)
    {
        if (!dic.ContainsValue(value))
            dic.Add(value.identity, value);
    }
    public FSMState<T> GetState(T key)
    {
        if (dic.ContainsKey(key))
        {
            return dic[key];
        }
        return null;
    }
}
