using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class MadLight : MonoBehaviour
{
    Animator _anim;
    public WallPuzzleManager Start;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    public void PlayAnimation()
    {
        _anim.Play("MadLight");
    }
    public void UnLockPlayer()
    {
        Manager.Instance.ConnectPlayer(false);
    }
    public void UpPlayer()
    {
        Manager.Instance.CameraSteps.Up();
    }
    public void StartPuzzle()
    {
        Start.StartPuzzle();
    }
    public void Done()
    {
        Start.Realize();
    }
    public void PreperNextStage()
    {

    }
}
