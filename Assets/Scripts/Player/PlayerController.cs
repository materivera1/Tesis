using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;

    private void Update()
    {
        player.Move(new Vector3(Input.GetAxis("Horizontal"), player.transform.position.y, Input.GetAxis("Vertical")));
        //player.Crounch(Input.GetKey(KeyCode.LeftControl));
    }
}
