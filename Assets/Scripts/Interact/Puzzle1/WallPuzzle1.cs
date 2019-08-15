using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class WallPuzzle1 : MonoBehaviour, IInteractive
{
    public List<WallPuzzleNode1> Walls;
    public List<WallPuzzleNode1> puzzleWalls;
    Dictionary<WallPuzzleNode1, int> puzzleIndex;
    public WallPuzzleManager wallManager;
    LayerMask lay;
    public float smooth;
    public float timer;
    public bool isInteractive { get; set; }
    float counter;
    bool isStart;
    bool senseStart;
    int numRandom;
   public bool isAvailable;
    public float waitForStart;
    public void Awake()
    {
        isAvailable = false;
        isInteractive = false;
        isStart = false;
    }
    public void StartPuzzle()
    {
        isAvailable = true;
        isInteractive = true;
        puzzleIndex = GetIndexPuzzleWalls(puzzleWalls);
        numRandom = Random.Range(2, 8);
        counter = 0;
        int sense = Random.Range(0, 2);
        if (sense == 0)
            senseStart = false;
        else
            senseStart = true;
        StartCoroutine("WaitForStart");
    }
    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(waitForStart);
        isStart = true;
    }
    public void Update()
    {
        if (!isAvailable) return;
        if (isStart)
        {
            while (numRandom > 0)
            {
                counter += Time.deltaTime;
                if (counter > timer)
                {
                    Walls = MoveWall(Walls, senseStart);
                    counter = 0;
                    numRandom--;
                }
                return;
            }
            isStart = false;
            isInteractive = true;
        }
        if (!isInteractive && Input.GetMouseButton(0))
        {
            counter += Time.deltaTime;
            var axis = Input.GetAxis("Mouse X");
            if (counter + Mathf.Abs(axis) / smooth > timer)
            {
                if (axis > 0)
                {
                    Walls = MoveWall(Walls, true);
                    wallManager.CheckRealize();
                }
                else if (axis < 0)
                {
                    Walls = MoveWall(Walls, false);
                    wallManager.CheckRealize();
                }
                counter = 0;
            }
        }
        else
        {
            isInteractive = true;
        }
    }
    public void Interact()
    {
        if (isInteractive)
        {
            /*
            var cameraPos = Manager.Instance.cameraInteractive;
            RaycastHit hit;
            if (Physics.Raycast(cameraPos.transform.position, cameraPos.transform.forward, out hit, cameraPos.sight, lay))
            {
                if (Walls.Contains(hit.collider.gameObject))
                {
                    _index = Walls.IndexOf(hit.collider.gameObject);
                }
            }*/
            counter = 0;
            isInteractive = false;
        }
    }
    public List<WallPuzzleNode1> MoveWall(List<WallPuzzleNode1> list, bool isLeft)
    {
        list = ObjMove(list, isLeft);
        list = ListMove(list, isLeft);
        return list;
    }
    public List<WallPuzzleNode1> ObjMove(List<WallPuzzleNode1> list, bool isLeft)
    {
        if (isLeft)
        {
            var auxPo = list.First().GetPos;
            var auxRot = list.First().GetRot;
            for (int i = 0; i < list.Count - 1; i++)
            {
                list[i].Move(list[i + 1].GetPos, list[i + 1].GetRot);
            }
            list.Last().Move(auxPo, auxRot);
        }
        else
        {
            var auxPo = list.Last().GetPos;
            var auxRot = list.Last().GetRot;
            for (int i = list.Count - 1; i > 0; i--)
            {
                list[i].Move(list[i - 1].GetPos, list[i - 1].GetRot);
            }
            list.First().Move(auxPo, auxRot);
        }
        return list;
    }
    public List<WallPuzzleNode1> ListMove(List<WallPuzzleNode1> list, bool isLeft)
    {
        List<WallPuzzleNode1> newList = new List<WallPuzzleNode1>();
        if (isLeft)
        {
            newList.Add(list.Last());
            newList.AddRange(list.GetRange(0, list.Count - 1));
        }
        else
        {
            newList.AddRange(list.GetRange(1, list.Count - 1));
            newList.Add(list.First());
        }
        return newList;
    }
    public Dictionary<WallPuzzleNode1, int> GetIndexPuzzleWalls(List<WallPuzzleNode1> nodes)
    {
        var dic = new Dictionary<WallPuzzleNode1, int>();
        foreach (var item in nodes)
        {
            dic.Add(item, Walls.IndexOf(item));
        }
        return dic;
    }
    public bool CheckWallPuzzle()
    {
        if (puzzleWalls.Count == 0) return true;
        bool isTrue = false;
        foreach (var item in puzzleWalls)
        {
            if (puzzleIndex.ContainsKey(item) && puzzleIndex[item] == Walls.IndexOf(item))
            {
                isTrue = true;
            }
        }
        return isTrue;
    }
}
