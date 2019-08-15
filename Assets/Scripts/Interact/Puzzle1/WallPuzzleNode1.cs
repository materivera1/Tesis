using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPuzzleNode1 : MonoBehaviour
{
    Vector3 _myPos;
    Quaternion _myRot;
    public bool isMove { get; private set; }
    public float smooth = 5f;
    List<Vector3> _pos = new List<Vector3>();
    List<Quaternion> _rot = new List<Quaternion>();
    public void Start()
    {
        _myPos = transform.position;
        _myRot = transform.rotation;
        isMove = false;
    }
    public void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.Lerp(transform.position, _myPos, Time.deltaTime * smooth);
            transform.rotation = Quaternion.Lerp(transform.rotation, _myRot, Time.deltaTime * smooth);
            if (Vector3.Distance(transform.position, _myPos) < 0.01f && Quaternion.Angle(transform.rotation, _myRot) < 0.01f)
            //if (transform.position == proxPos && transform.rotation == proxRot)
            {/*
                if (_pos.Count > 0 && _rot.Count > 0)
                {
                    _myPos = _pos.First();
                    _myRot = _rot.First();
                    _pos.Remove(_pos.First());
                    _rot.Remove(_rot.First());
                }
                else
                {*/
                    transform.position = _myPos;
                    transform.rotation = _myRot;
                    isMove = false;
                /*}*/
            }
        }
    }
    public void Move(Vector3 newPos, Quaternion newRot)
    {/*
        if (Vector3.Distance(transform.position, _myPos) >= 0.01f && Quaternion.Angle(transform.rotation, _myRot) >= 0.01f)
        {
            _pos.Add(newPos);
            _rot.Add(newRot);
        }
        else
        {*/
            _myPos = newPos;
            _myRot = newRot;
        /*}*/
        isMove = true;
    }
    public Vector3 GetPos
    {
        get
        {
            if (_pos.Count > 0)
            {
                return _pos.Last();
            }
            else
            {
                return _myPos;
            }
        }
    }
    public Quaternion GetRot
    {
        get
        {
            if (_rot.Count > 0)
            {
                return _rot.Last();
            }
            else
            {
                return _myRot;
            }
        }
    }

}
