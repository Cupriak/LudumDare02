using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInteractable : MonoBehaviour, IInteractable
{
    public void Interact(GameObject target)
    {
        Debug.Log("Interaction");
    }
}
