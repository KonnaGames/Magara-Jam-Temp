using UnityEngine;

public class ArcadeMachineBolum1 : MonoBehaviour, IInteractable
{
    public string interactionName { get; private set; }
    public bool isInteracted { get; private set; }
    private void Start()
    {
        interactionName = "Insert Coin";
    }
    public void Interact()
    {
        DialogueManage.instance.StartStoryDialogue();
        // LoadingScreen.instance.LoadScene("Dialogue Gelicek",2);
        isInteracted = true;
    }
}
