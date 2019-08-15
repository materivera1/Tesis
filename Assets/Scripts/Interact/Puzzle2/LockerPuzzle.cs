using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LockerPuzzle : MonoBehaviour
{
    public List<Locker> allLockers;

    public Locker lastLocker;

    public List<Locker> correctLockers;

    public GameObject brand;

    public float myTime;

    bool _solved;

    public GameObject[] ObjHide;
    public float timeLigthoff;
    private void Start()
    {
        brand.SetActive(false);
    }

    void Update()
    {
        CheckLockers();
        Debug.Log("Lockers correctos " + correctLockers.Count);
    }
    void CheckLockers()
    {
        if (!_solved)
        {
            foreach (var item in allLockers)
            {
                if (!item.fromPuzzle && item.state == Locker.States.Opened)
                {
                    StartCoroutine(CloseAll());
                }
                else if (item.fromPuzzle && item.state == Locker.States.Opened)
                {
                    if (!correctLockers.Contains(item) && item.state == Locker.States.Opened)
                    {
                        correctLockers.Add(item);
                    }
                    if (correctLockers.Contains(item) && item.state == Locker.States.Closed)
                    {
                        correctLockers.Remove(item);
                    }
                }
            }
            if (correctLockers.Count == 11)
            {
                PuzzleSolved();
                _solved = true;
                correctLockers = new List<Locker>();
            }
        }
    }
    IEnumerator CloseAll()
    {
        foreach (var item in allLockers)
        {
            item.isInteractive = false;
        }
        yield return new WaitForSeconds(myTime);
        foreach (var item in allLockers)
        {
            item.isInteractive = true;
        }
        CloseAllLockers();
    }
    void CloseAllLockers()
    {
        foreach (var item in allLockers)
        {
            if (item.state == Locker.States.Opened)
            {
                item.CloseLocker();
                correctLockers = new List<Locker>();
            }
        }
    }

    void PuzzleSolved()
    {
        StartCoroutine(OpenLastLocker());
    }
    IEnumerator OpenLastLocker()
    {
        var lights = GameObject.FindObjectsOfType<Light>();
        yield return new WaitForSeconds(myTime);
        lastLocker.OpenLocker();
        lastLocker.fromPuzzle = true;
        brand.SetActive(true);
        CloseAllLockers();
        yield return new WaitForSeconds(myTime);
        lastLocker.isInteractive = false;
        //yield return null;
        foreach (var item in lights)
        {
            item.enabled = false;
        }
        foreach (var item in ObjHide)
        {
            item.SetActive(false);
        }
        yield return new WaitForSeconds(timeLigthoff);
        foreach (var item in lights)
        {
            item.enabled = true;
        }
    }
}
