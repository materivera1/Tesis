using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SwitchObj : MonoBehaviour
{
    public List<GameObject> ObjtoHide;
    public List<GameObject> ObjtoShow;

    public void Switch()
    {
        foreach (var item in ObjtoHide)
        {
            item.SetActive(false);
        }

        foreach (var item in ObjtoShow)
        {
            item.SetActive(true);
        }
    }
    public void ReverseSwitch()
    {

        foreach (var item in ObjtoHide)
        {
            item.SetActive(true);
        }
        foreach (var item in ObjtoShow)
        {
            item.SetActive(false);
        }
    }
}
