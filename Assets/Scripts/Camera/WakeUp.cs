using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class WakeUp : MonoBehaviour
{
    public Animator Camera;
    public PostProcessVolume post;
    Vignette vig;
    float intensity;
    float counter;
    float counterWakeUp;
    float counterTravel;
    public float timeToWakeUp;
    bool IsWake;
    bool IsStart;
    public GameObject player;
    public Transform CameraPos;
    public float delay;
    private void Awake()
    {
        post.profile.TryGetSettings(out vig);
        vig.intensity.Override(1f);
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (counterWakeUp >= timeToWakeUp)
        {
            if (vig.intensity.value > 0.5f)
            {
                counter += Time.deltaTime;
                vig.intensity.Interp(vig.intensity.value, 0.45f, counter / delay);
            }
            else
            {
                if (!IsWake)
                {
                    Camera.Play("WakeUp");
                    IsWake = true;
                }
                else if (IsStart)
                {
                    if (Vector3.Distance(transform.parent.position, CameraPos.position) > 0.1f)
                    {

                        counterTravel += Time.deltaTime;
                        transform.parent.position = Vector3.Lerp(transform.parent.position, CameraPos.position, counterTravel);
                    }
                    else
                    {
                        
                    }
                }
            }
        }
        else
        {
            counterWakeUp += Time.deltaTime;
        }
    }
    public void StartGame()
    {
        player.active = true;
        Destroy(this.gameObject);

    }
}
