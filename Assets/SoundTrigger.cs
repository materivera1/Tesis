using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource As;
    public AudioClip sound;
    public BoxCollider col;
    public GameObject nextSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            As.PlayOneShot(sound);
            Destroy(col);
            if (nextSound != null)
            {
                nextSound.SetActive(true);
            }
        }
    }
}
