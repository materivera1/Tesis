using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEvent : MonoBehaviour
{
    Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    public void PlayAnimation(string name)
    {
        _anim.Play(name);
    }
}
