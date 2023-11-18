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

        if (currentDialogue == 0)
        {
            // StartStoryDialogue();
        }
    }

    public void HikayeSifirla()
    {
        currentDialogue = 0;
    }

    [ContextMenu("Diayalogu Oynat")]
    public void StartStoryDialogue()
    {
        if (isPlaying || currentDialogue > StoryDialgouesLines.Count - 1) return;
        
        isPlaying = true;
        _audioSource.clip = StoryDialgouesLines[currentDialogue].voice;
        _audioSource.Play();
        DialoguePanel.SetActive(true);
        text.text = StoryDialgouesLines[currentDialogue].Line;

        StoryDialgouesLines[currentDialogue].myEvent?.Invoke();

        if (StoryDialgouesLines[currentDialogue].tartismaID == StoryDialgouesLines[currentDialogue + 1].tartismaID)
            Invoke(nameof(ContinueDialogue), 2f);
        else
        {
            Invoke(nameof(CloseDialogue), 2);
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
        if (isPlaying) return;

        int randomInt = Random.Range(0, CustomDialogueLines.Count);
        
        isPlaying = true;
        _audioSource.clip = CustomDialogueLines[randomInt].voice;
        _audioSource.Play();
        customText.text = CustomDialogueLines[randomInt].Line;
        CustomDialoguePanel.SetActive(true);
        
        Invoke(nameof(CloseCustomDialogue), 1);
    }

    private void CloseDialogue()
    {
        isPlaying = false;
        DialoguePanel.SetActive(false);
    }


    private void CloseCustomDialogue()
    {
        isPlaying = false;
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

    public MyEvent myEvent;
}

[Serializable]
public class MyEvent : UnityEvent {}