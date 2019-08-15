using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSound : MonoBehaviour
{
    AudioSource _audio;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    public void SingleSound(AudioClip clip)
    {
        _audio.clip = clip;
        _audio.Play();
    }
    public void RandomSound(AudioClip[] clips)
    {
        int num = Random.Range(0, clips.Length);
        _audio.clip = clips[num];
        _audio.Play();
    }
}
