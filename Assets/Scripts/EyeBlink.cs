using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EyeBlink : MonoBehaviour
{
    public PostProcessVolume post;
    Vignette vig;
    float initIntensitive;
    public float eyesOpen;
    public float smooth;
    public float speed;
    void Start()
    {
        post.profile.TryGetSettings(out vig);
        initIntensitive = vig.intensity.value;
    }
    public void CallOpenEyes()
    {
        StartCoroutine("OpenEyes");
        Debug.Log("LLAMAR");
    }
    IEnumerator OpenEyes()
    {
        if (vig.intensity > eyesOpen)
        {
            vig.intensity.Override(vig.intensity.value - speed);
            yield return new WaitForSeconds(smooth);
            StartCoroutine("OpenEyes");
        }
    }
}
