using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class DialogueManage : MonoBehaviour
{
    public static DialogueManage instance;
    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private GameObject CustomDialoguePanel;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI customText;

    [SerializeField] private Actor Jhon;
    
    public List<DialogueLine> StoryDialgouesLines;
    public List<DialogueLine> CustomDialogueLines;
    
    public int currentDialogue;
    public bool isPlaying;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if(instance != this) Destroy(this.gameObject);
        
        //TODO : Daha sonrasinda kaldir
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        DialoguePanel.SetActive(false);
        CustomDialoguePanel.SetActive(false);

        isPlaying = false;
        
        //TODO: Bu kismini savelemek lazim.
        currentDialogue = 0;
    }

    public void HikayeSifirla()
    {
        currentDialogue = 0;
    }

    [ContextMenu("Diayalogu Oynat")]
    public void StartStoryDialogue()
    {
        // Eger custom dialogue aciksa kapaticak
        CloseCustomDialogue();
        
            
        if (isPlaying || currentDialogue > StoryDialgouesLines.Count - 1) return;
        
        isPlaying = true;
        _audioSource.clip = StoryDialgouesLines[currentDialogue].voice;
        _audioSource.Play();
        
        if (StoryDialgouesLines[currentDialogue].actor.name == Jhon.name)
        {
            DialoguePanel.SetActive(true);
        }
        else
        {
            DialoguePanel.SetActive(false);
        }
        
        StoryDialgouesLines[currentDialogue].dialogueBaslangicEvent?.Invoke();
        
        text.text = StoryDialgouesLines[currentDialogue].Line;


        if (StoryDialgouesLines[currentDialogue].tartismaID == StoryDialgouesLines[currentDialogue + 1].tartismaID)
        {
            if (StoryDialgouesLines[currentDialogue].voice != null)
                Invoke(nameof(ContinueDialogue), StoryDialgouesLines[currentDialogue].voice.length);
            else
            {
                Invoke(nameof(ContinueDialogue), 3f);
            }
        }
        else
        {
            if (StoryDialgouesLines[currentDialogue].voice != null)
                Invoke(nameof(CloseDialogue), StoryDialgouesLines[currentDialogue].voice.length);
            else
            {
                Invoke(nameof(CloseDialogue), 3f);
            }
        }
       
        currentDialogue++;
    }


    private void ContinueDialogue()
    {
        isPlaying = false;
        StartStoryDialogue();
    }

    /// <summary>
    /// Random Dalga Gecme Diyaloglari
    /// </summary>
    public void StartCustomDialogue()
    {
        int randomInt = Random.Range(0, CustomDialogueLines.Count);
        
        _audioSource.clip = CustomDialogueLines[randomInt].voice;
        _audioSource.Play();
        customText.text = CustomDialogueLines[randomInt].Line;
        CustomDialoguePanel.SetActive(true);
        

        if (CustomDialogueLines[randomInt].voice != null)
            Invoke(nameof(CloseCustomDialogue), CustomDialogueLines[randomInt].voice.length);
        else
        {
            Invoke(nameof(CloseCustomDialogue), 2f);
        }
    }

    private void CloseDialogue()
    {
        isPlaying = false;
        DialoguePanel.SetActive(false);
        StoryDialgouesLines[currentDialogue - 1].dialogueSonundakiEvent?.Invoke();
    }

    private void CloseCustomDialogue()
    {
        _audioSource.Stop();
        CustomDialoguePanel.SetActive(false);
    }
}


[Serializable]
public class DialogueLine
{
    public Actor actor;
    public AudioClip voice;
    [TextArea(3,3)]
    public string Line;

    public int tartismaID;

    public UnityEvent dialogueBaslangicEvent;
    public UnityEvent dialogueSonundakiEvent;
}