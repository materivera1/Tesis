using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{
    public float speed;
    public float time;
    public Image obj;
    Color _initColor;
    public bool canTransition;
    public bool isStartIn;
    public bool isStartOut;
    public void Start()
    {
        _initColor = obj.color;
        if (isStartIn)
            StartCoroutine(FadeIn());
        if (isStartOut)
            StartCoroutine(FadeOut());
    }
    public IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(time);
        obj.color = Color.Lerp(obj.color,Color.black,speed);
        if (obj.color != Color.black)
        {
            StartCoroutine(FadeIn());
        }
        else
        {
            if (canTransition)
                StartCoroutine(FadeOut());
        }
    }
    public IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(time);
        obj.color = Color.Lerp(obj.color, Color.clear, speed);
        if (obj.color != Color.clear)
        {
            StartCoroutine(FadeOut());
        }
    }
}
