using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;

	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
	}

	void Update ()
    {
        Movement();
	}

    void Movement()
    {
        var forward = Input.GetAxis("Vertical") * speed;
        var horizontal = Input.GetAxis("Horizontal") * speed;
        forward *= Time.deltaTime;
        horizontal *= Time.deltaTime;
        transform.Translate(horizontal, 0, forward);
    }
    void CursorOn()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
