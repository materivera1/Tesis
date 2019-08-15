using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggerLoop : MonoBehaviour
{
    public AudioSource As;
    public BoxCollider col;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            As.Play();
            Destroy(col);
        }
    }
}
