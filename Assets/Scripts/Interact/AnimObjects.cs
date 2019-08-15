using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class AnimObjects : LineOfSight
{
    public enum Mods
    {
        Range,
        IsView,
        IsViewRay
    }
    public Mods mode;
    Animator _anim;
    public Transform target;
    public float range;
    public float angle;
    public string clip;
    bool isAnimation;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (mode == Mods.Range && !IsRange(target, range) && !isAnimation) { return; }
        if (mode == Mods.IsView && !IsView(target, range, angle)) { return; }
        if (mode == Mods.IsViewRay && !IsViewRay(target, range, angle)) { return; }
        isAnimation = true;
        _anim.Play(clip);

    }/*
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        if (mode == Mods.IsView)
        {
            if (IsView(target, range, angle)) Gizmos.color = Color.red;
            else Gizmos.color = Color.white;
        }
        if (mode == Mods.IsViewRay)
        Gizmos.DrawRay(transform.position, target.transform.position - transform.position);
    }*/
}
