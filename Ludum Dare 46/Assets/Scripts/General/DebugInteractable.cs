using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInteractable : MonoBehaviour, IInteractable
{
    void IInteractable.Interact()
    {
        Debug.Log("Interaction");
    }
}
