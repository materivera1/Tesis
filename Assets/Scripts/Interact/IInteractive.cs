using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive
{
    void Interact();
    bool isInteractive { get; set; }
}
