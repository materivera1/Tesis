using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour, IObservable
{
    public AudioSource audio;
    public List<AudioClip> clips;
    public List<AudioClip> clipsRandom;
    public AudioClip OpenObsClip;
    public bool Openloop;
    public float Opendelay;
    public AudioClip CloseObsClip;
    public bool Closeloop;
    public float Closedelay;
    public void RandomFromScript()
    {
        int r = Random.Range(0, clipsRandom.Count - 1);
        audio.Stop();
        audio.clip = clipsRandom[r];
        audio.Play();
    }
    public void RandomClips(AudioClip[] c)
    {
        int r = Random.Range(0, c.Length - 1);
        audio.Stop();
        audio.clip = c[r];
        audio.Play();
    }
    public void PlayFromScript(int index)
    {
        if (index >= clips.Count) return;
        audio.Stop();
        audio.clip = clips[index];
        audio.Play();
    }
    public void PlayClip(AudioClip c)
    {
        audio.Stop();
        audio.clip = c;
        audio.Play();

    }
    public void PlayClipLoop(AudioClip c, bool loop)
    {
        audio.Stop();
        audio.clip = c;
        audio.Play();
        audio.loop = loop;
    }
    public void Close()
    {
        StartCoroutine(PlayClipDelay(Closedelay, CloseObsClip, Closeloop));
    }
    public void Open()
    {
        StartCoroutine(PlayClipDelay(Opendelay, OpenObsClip, Openloop));
    }
    IEnumerator PlayClipDelay(float delay, AudioClip c, bool loop)
    {
        yield return new WaitForSeconds(delay);
        PlayClipLoop(c, loop);
    }
}
