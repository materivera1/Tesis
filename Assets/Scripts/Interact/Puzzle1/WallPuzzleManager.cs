using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class WallPuzzleManager : MonoBehaviour
{
    public List<WallPuzzle1> wallPuzzle;
    public bool isRealize;
    public Animator _madlight;
    public GameObject[] doorHide;
    public GameObject[] doorShow;
    public GameObject[] ObjHideForever;
    public GameObject[] ObjShowRealize;
    public Door door;
    public void StartPuzzle()
    {
        foreach (var item in ObjHideForever)
        {
            item.SetActive(false);
        }
        foreach (var item in ObjShowRealize)
        {
            item.SetActive(true);
        }
        foreach (var item in doorShow)
        {
            item.SetActive(true);
        }

        foreach (var item in doorHide)
        {
            item.SetActive(false);
        }
        foreach (var item in wallPuzzle)
        {
            item.StartPuzzle();
        }
    }
    public void CheckRealize()
    {
        foreach (var item in wallPuzzle)
        {
            if (!item.CheckWallPuzzle())
            {
                isRealize = false;
                return;
            }
        }
        _madlight.Play("MadLigth_Realize");
        isRealize = true;
        foreach (var item in wallPuzzle)
        {
            item.isAvailable = false;
        }
        return;
    }
    public void Realize()
    {
        foreach (var item in doorShow)
        {
            item.SetActive(false);
        }
        foreach (var item in doorHide)
        {
            item.SetActive(true);
        }
        door.ResetDoor();
        door.ChangeDistanceClose(3);
    }
}
