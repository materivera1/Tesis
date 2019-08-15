using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Manager : MonoBehaviour
{
    int counter = 0;
    DoorPuzzle current;
    public List<DoorPuzzle> list;
    public Vector3 pos;
    public Vector3 rot;
    public Vector3 donePos;
    public Vector3 doneRot;
    public GameObject[] objToHide;
    public GameObject[] doneObj;
    public GameObject[] doneObjPuzzle;
    public float timeToRestart;
    void Start()
    {
        SetPuzzleManager();
        list = RandomPuzzle(list);
        SetClue(list);
        for (int i = 0; i < doneObj.Length; i++)
        {
            doneObj[i].SetActive(false);
        }
    }
    void Done()
    {
        Manager.Instance.DisconnectPlayer();
        Manager.Instance.player.transform.position = donePos;
        Manager.Instance.player.transform.eulerAngles = doneRot;
        StartCoroutine(ShowDoneForTime());
    }
    public void CallPuzzle(DoorPuzzle dp)
    {
        if (list[counter].Equals(dp))
        {
            counter++;
            SetClue(list);
            if (counter >= list.Count)
            {
                Debug.Log("DONE");
                Done();
                return;
            }
        }
        else
        {
            counter = 0;
            SetClue(list);
        }
        ClosedDoor(list);
        Manager.Instance.DisconnectPlayer(true, true);
        Manager.Instance.player.transform.position = pos;
        Manager.Instance.player.transform.eulerAngles = rot;
        StartCoroutine(ShowObjsForTime());
    }
    void ClosedDoor(List<DoorPuzzle> l)
    {
        foreach (var item in l)
        {
            item.ResetDoor();
        }
    }
    List<DoorPuzzle> RandomPuzzle(List<DoorPuzzle> l)
    {
        var newlist = new List<DoorPuzzle>();
        for (int i = 0; i < l.Count; i++)
        {
            newlist.Add(l[i]);
        }
        var rList = new List<DoorPuzzle>();
        for (int i = 0; i < l.Count; i++)
        {
            int randomNum = Random.Range(0, newlist.Count);
            rList.Add(newlist[randomNum]);
            newlist.RemoveAt(randomNum);
        }
        return rList;
    }
    public void SetClue(List<DoorPuzzle> l)
    {
        if (counter >= l.Count) return;
        for (int i = 0; i < l.Count; i++)
        {
            if (counter == i)
                l[i].ShowClue();
            else
                l[i].HideClue();
        }
    }
    void SetPuzzleManager()
    {
        foreach (var item in list)
        {
            item.SetManager(this);
        }
    }
    public void HideObjs()
    {
        for (int i = 0; i < objToHide.Length; i++)
        {
            objToHide[i].SetActive(false);
        }
    }
    public void ShowObjs()
    {
        for (int i = 0; i < objToHide.Length; i++)
        {
            objToHide[i].SetActive(true);
        }
    }
    IEnumerator ShowObjsForTime()
    {
  
        Manager.Instance.ConnectPlayer(true);
        yield return new WaitForSeconds(timeToRestart);
        for (int i = 0; i < objToHide.Length; i++)
        {
            objToHide[i].SetActive(true);
        }
    }
    IEnumerator ShowDoneForTime()
    {
        Manager.Instance.ConnectPlayer(true);
        yield return new WaitForSeconds(timeToRestart);
        for (int i = 0; i < doneObj.Length; i++)
        {
            doneObj[i].SetActive(true);
        }
        for (int i = 0; i < doneObjPuzzle.Length; i++)
        {
            doneObjPuzzle[i].SetActive(false);
        }

    }
}
