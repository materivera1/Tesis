using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigthOnOff : LineOfSight
{
    AudioSource _audio;
    public enum Mods
    {
        Range,
        IsView,
        IsViewRay
    }
    public Mods mode;
    public float range;
    public float angle;
    public Transform target;
    public Light lamp;
    bool isPlay;
    float intensity;
    public List<GameObject> LigthAll;
    private void Start()
    {
        intensity = lamp.intensity;
        _audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (mode == Mods.Range && !IsRange(target, range)) { return; }
        if (mode == Mods.IsView && !IsView(target, range, angle)) { return; }
        if (mode == Mods.IsViewRay && !IsViewRay(target, range, angle)) { return; }
        if (!isPlay)
        {
            isPlay = true;
            StartCoroutine("Play");
        }
    }
    IEnumerator Play()
    {
        lamp.intensity = 0;
        yield return new WaitForSeconds(0.08f);
        lamp.intensity = intensity;
        yield return new WaitForSeconds(0.1f);
        lamp.intensity = 0;
        yield return new WaitForSeconds(0.2f);
        lamp.intensity = intensity;
        foreach (var item in LigthAll)
        {
            if (item.gameObject != this.gameObject)
                item.SetActive(false);
        }
        _audio.Play();
    }

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
    }
}
