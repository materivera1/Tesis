using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteractive : MonoBehaviour
{
    public float sight;
    public LayerMask lay;
    public GameObject InterHud;
    public void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, sight, lay))
        {
            var obj = hit.collider.GetComponent<IInteractive>();
            if (obj != null)
            {
                if (InterHud.activeInHierarchy == false && obj.isInteractive)
                    InterHud.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    obj.Interact();
                }
            }
        }
        else if (InterHud.activeInHierarchy == true)
        {
            InterHud.SetActive(false);
        }
    }

}
