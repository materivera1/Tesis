using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundByDistance : LineOfSight
{
    public enum Mods
    {
        Range,
        IsView,
        IsViewRay
    }
    public Mods mode;
    public Transform target;
    public float range;
    public float angle;
    bool isDone;
    public AudioSource audio;
    public AudioClip clip;
    private void Start()
    {
        isDone = false;
    }
    void Update()
    {
        if (isDone) return;
        if (mode == Mods.Range && !IsRange(target, range)) { return; }
        if (mode == Mods.IsView && !IsView(target, range, angle)) { return; }
        if (mode == Mods.IsViewRay && !IsViewRay(target, range, angle)) { return; }
        audio.Stop();
        audio.clip = clip;
        audio.Play();
        isDone = true;
    }
}
