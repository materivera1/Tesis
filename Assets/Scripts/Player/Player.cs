using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player : MonoBehaviour
{

    float _speed;
    public float upSpeed;
    public float downSpeed;
    public float crounchSpeed;
    public float capHeight;
    float capInitHeight;
    Rigidbody _rb;
    CapsuleCollider _capColl;
    public LayerMask lay;
    public PhysicMaterial frinctionCollider;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _capColl = GetComponent<CapsuleCollider>();
        capInitHeight = _capColl.height;
        _speed = upSpeed;
    }
    public void Move(Vector3 dir)
    {
        dir = transform.rotation * dir * _speed;
        dir.y = _rb.velocity.y;
        _rb.velocity = dir;
    }
    public void Crounch(bool ifCrounch)
    {
        var lastHeight = _capColl.height;
        if (ifCrounch)
        {
            _capColl.height = Mathf.Lerp(_capColl.height, capHeight, crounchSpeed * Time.deltaTime);
            _speed = downSpeed;
        }
        else
        {
            _capColl.height = Mathf.Lerp(_capColl.height, capInitHeight, crounchSpeed * Time.deltaTime);
            _speed = upSpeed;
        }
        transform.position = transform.position + Vector3.up * ((_capColl.height - lastHeight) / 2);
    }
}