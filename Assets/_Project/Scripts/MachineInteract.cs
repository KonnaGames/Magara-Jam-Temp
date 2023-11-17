using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineInteract : MonoBehaviour , IInteractable
{
    public string interactionName => "Insert Coin";


    public bool isInteracted { get; private set; }

    public void Interact()
    {
        Debug.Log("Interact");
        isInteracted = true;
    }
    private void Start()
    {
        isInteracted = false;
    }
}
