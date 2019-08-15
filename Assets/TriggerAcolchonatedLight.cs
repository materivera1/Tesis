using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAcolchonatedLight : MonoBehaviour
{
    public GameObject light;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            light.SetActive(true);
        }
    }
}
