using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManage : MonoBehaviour
{
    public List<DialogueLine> BirDDialogueLines;
    public int BirDDialogueInt;
    public List<DialogueLine> IkiDDialogueLines;
    public int IkiDDialogueInt;
    public List<DialogueLine> UcDDialogueLines;
    public int UcDDialogueInt;
}


[Serializable]
public class DialogueLine
{
    public Actor actor;
    [TextArea(3,3)]
    public string Line;
}