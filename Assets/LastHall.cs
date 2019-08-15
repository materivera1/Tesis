using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LastHall : MonoBehaviour
{
    Animator _anim;
    public Animator[] objAnim;
    public GameObject[] obj;

    bool isStart;

    public void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void PlayAnimation(int index)
    {
        if (index >= objAnim.Length) return;
        objAnim[index].Play("Drop");
        obj[index].SetActive(false);
        obj[index].SetActive(false);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (!isStart)
        {
            _anim.Play("Event");
            isStart = true;
        }
    }
    public void NextScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ChangeMaterial()
    {

    }
}

