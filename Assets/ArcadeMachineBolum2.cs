using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMachineBolum2 : MonoBehaviour, IInteractable
{
    public string interactionName { get; private set; }

    public string interactinName2;

    public bool isInteracted { get; private set; }
    
    private void Start()
    {
        interactionName = interactinName2;
        isInteracted = false;
    }
    
    public void Interact()
    {
        DialogueManage.instance.StartStoryDialogue();
        isInteracted = true;
    }

    public void InteractiAc()
    {
        isInteracted = false;
    }
}
