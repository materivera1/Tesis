using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    Vector2 _mouseLook;
    Vector2 _smoothView;
    public float sensitivity;
    public float smooth;
    public float zoom;
    float zoomInit;
    public float zoomTime;
    float currentTime = 0;
    public Transform _character;
    void Start()
    {
        ResetRot();
    }

    void Update()
    {
        RotateLook();
        ZoomView();
    }

    void RotateLook()
    {
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smooth, sensitivity * smooth));
        _smoothView.x = Mathf.Lerp(_smoothView.x, mouseDelta.x, 1f / smooth);
        _smoothView.y = Mathf.Lerp(_smoothView.y, mouseDelta.y, 1f / smooth);
        _mouseLook += _smoothView;
        transform.localRotation = Quaternion.AngleAxis(-_mouseLook.y, Vector3.right);
        _character.transform.localRotation = Quaternion.AngleAxis(_mouseLook.x, _character.transform.up);
    }
    void ZoomView()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonUp(1))
        {
            currentTime = 0;
        }

        if (Input.GetMouseButton(1))
        {
            currentTime += Time.deltaTime;
            Camera.main.fieldOfView -= 1f * currentTime / zoomTime;
            if (Camera.main.fieldOfView <= zoom) Camera.main.fieldOfView = zoom;
        }
        else
        {

            if (Camera.main.fieldOfView >= zoom)
            {
                currentTime += Time.deltaTime;
                Camera.main.fieldOfView += 1f * currentTime * 2 / zoomTime;
                if (Camera.main.fieldOfView >= zoomInit) Camera.main.fieldOfView = zoomInit;
            }
        }
    }
    public void ResetRot()
    {
        Input.ResetInputAxes();
        zoomInit = Camera.main.fieldOfView;
        _mouseLook.x = _character.localEulerAngles.y;
        _mouseLook.y = 0;
        _smoothView = Vector2.zero;
        currentTime = 0;
    }
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void UnLockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
