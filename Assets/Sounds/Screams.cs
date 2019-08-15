using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screams : MonoBehaviour
{
    public AudioSource AS;
    public List<AudioClip> sounds;
    public List<AudioClip> playedClips;
    public float timer;
    public int index;

    private void Start()
    {
        timer = Random.Range(50, 100);
        index = Random.Range(0, sounds.Count);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            AS.PlayOneShot(sounds[index]);
            playedClips.Add(sounds[index]);
            sounds.RemoveAt(index);
            timer = Random.Range(50, 100);
            index = Random.Range(0, sounds.Count);
        }

        if (sounds.Count <= 0)
        {
            for (int i = 0; i < playedClips.Count; i++)
            {
                sounds.Add(playedClips[i]);
                if (i == 3)
                {
                    playedClips.Clear();
                }
            }
        }
    }
}
