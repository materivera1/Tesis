using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
    }
}
