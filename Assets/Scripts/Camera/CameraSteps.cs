using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSteps : MonoBehaviour
{
    Animator _anim;
    bool _isWalk;
    public Rigidbody rb;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            _isWalk = true;
        else
            _isWalk = false;
        _anim.SetBool("IsWalk", _isWalk);
    }
    public void Sit()
    {
        _isWalk = false;
        _anim.Play("Sit");
    }
    public void Up()
    {
        _anim.Play("Up");
    }
    public void Starting()
    {
        _anim.Play("WakeUp");
    }
    public void Idle()
    {
        _anim.Play("Camera_Idle");
    }
}
