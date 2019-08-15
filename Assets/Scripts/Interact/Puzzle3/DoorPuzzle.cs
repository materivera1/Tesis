using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle : Door
{
    public GameObject clue;
    public Puzzle3Manager puzzleManager;
    public GameObject[] objToHide;
    public float[] intervals;
    int current = 0;
    public override void OpenDoor()
    {
        base.OpenDoor();
        current = 0;
    }
    public override void ClosedDoor()
    {
        puzzleManager.HideObjs();
        base.ClosedDoor();
        if (puzzleManager == null) return;
        if (objToHide.Length != 0)
        {
            StartCoroutine(ObjsHide());
        }
        else
        {
            puzzleManager.CallPuzzle(this);
        }
    }
    public void SetManager(Puzzle3Manager manager)
    {
        puzzleManager = manager;
    }
    IEnumerator ObjsHide()
    {
        for (int i = 0; i < objToHide.Length; i++)
        {
            objToHide[i].SetActive(false);
        }
        yield return new WaitForSeconds(intervals[current]);
        if (current + 1 < intervals.Length)
        {
            for (int i = 0; i < objToHide.Length; i++)
            {
                objToHide[i].SetActive(true);
            }
            yield return new WaitForSeconds(intervals[current]);
        }
        current++;
        if (current < intervals.Length)
            StartCoroutine(ObjsHide());
        else
        {
            ResetDoor();
            puzzleManager.CallPuzzle(this);
            for (int i = 0; i < objToHide.Length; i++)
            {
                objToHide[i].SetActive(true);
            }
        }
    }

    public void HideClue()
    {
        Debug.Log(clue.name);
        clue.SetActive(false);
    }
    public void ShowClue()
    {
        clue.SetActive(true);
    }
}
