using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManage : MonoBehaviour
{
    public static DialogueManage instance;
    
    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TextMeshProUGUI text;
    
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

        isPlaying = false;
        
        //TODO: Bu kismini savelemek lazim.
        currentDialogue = PlayerPrefs.GetInt("StoryHolder");
    }

    public void HikayeSifirla()
    {
        currentDialogue = 0;
        PlayerPrefs.SetInt("Storyholder", 0);
    }

    [ContextMenu("Diayalogu Oynat")]
    public void StartStoryDialogue()
    {
        if (isPlaying || currentDialogue > StoryDialgouesLines.Count - 1) return;
        
        isPlaying = true;
        _audioSource.clip = StoryDialgouesLines[currentDialogue].voice;
        _audioSource.Play();
        text.text = StoryDialgouesLines[currentDialogue].Line;
        DialoguePanel.SetActive(true);

        currentDialogue++;
        PlayerPrefs.SetInt("Storyholder", currentDialogue);
        
        Invoke(nameof(CloseDialogue), _audioSource.clip.length + 1f);
    }

    public void StartCustomDialogue(int dialogueIndex)
    {
        if (isPlaying) return;
        
        isPlaying = true;
        _audioSource.clip = StoryDialgouesLines[dialogueIndex].voice;
        _audioSource.Play();
        text.text = StoryDialgouesLines[dialogueIndex].Line;
        DialoguePanel.SetActive(true);
        
        Invoke(nameof(CloseDialogue), _audioSource.clip.length + 1f);
    }
    
    private void CloseDialogue()
    {
        isPlaying = false;
        DialoguePanel.SetActive(false);
        if(StoryDialgouesLines[currentDialogue -1].sahneYukle != 0)
            LoadingScreen.instance.LoadScene(StoryDialgouesLines[currentDialogue -1].sahneYukle);
    }
}


[Serializable]
public class DialogueLine
{
    public Actor actor;
    public AudioClip voice;
    [TextArea(3,3)]
    public string Line;

    public int sahneYukle;
}