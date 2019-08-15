using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObj : MonoBehaviour, IInteractive
{
    public bool isInteractive { get; set; }
    Vector3 dir;
    Vector3 initDir;
    Quaternion initRot;
    public float distance;
    public float speed;
    public float speedRot;
    private void Start()
    {
        initDir = transform.position;
        initRot = transform.rotation;
        isInteractive = true;
    }
    public void Interact()
    {
        if (isInteractive)
        {
            isInteractive = false;
            dir = Camera.main.transform.position + (transform.position - Camera.main.transform.position).normalized * distance;
            Manager.Instance.DisconnectPlayer();

        }
    }
    void Update()
    {
        if (!isInteractive)
        {
            if (!Input.GetMouseButton(0))
            {
                isInteractive = true;
                Manager.Instance.ConnectPlayer();
            }
            if (Vector3.Distance(dir, transform.position) > 0.005f)
            {
                transform.position = Vector3.Lerp(transform.position, dir, speed);
            }
            else
            {
                RotateObj(Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"));
            }
        }
        else
        {
            if (Vector3.Distance(initDir, transform.position) > 0.005f)
            {
                transform.position = Vector3.Lerp(transform.position, initDir, speed);
            }
            if (Quaternion.Angle(initRot,transform.rotation)>0.05f){
                transform.rotation = Quaternion.Lerp(transform.rotation, initRot, speed);
            }
        }
    }
    void RotateObj(float Yaxis, float Xaxis)
    {
        transform.Rotate(new Vector3(0, -Xaxis * speedRot, Yaxis * speedRot));
        
    }
}
