using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManage : MonoBehaviour
{
    public List<DialogueLine> BoyutBirDialogues;
    public int BirDDialogueInt;
    public List<DialogueLine> BoyutIkiDialogues;
    public int IkiDDialogueInt;
    public List<DialogueLine> BoyutUcDialogues;
    public int UcDDialogueInt;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void GetBoyutBirDialogue()
    {
        
    }
}


[Serializable]
public class DialogueLine
{
    public Actor actor;
    [TextArea(3,3)]
    public string Line;
}