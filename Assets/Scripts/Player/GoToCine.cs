using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCine : MonoBehaviour
{
    public void UnlockPlayer()
    {
        Manager.Instance.ConnectPlayer(true);
    }
    public void LockPlayer()
    {
        Manager.Instance.DisconnectPlayer();
    }
}
