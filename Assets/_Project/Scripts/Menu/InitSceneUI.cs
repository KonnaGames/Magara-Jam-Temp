using System;
using System.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using TMPro;

public class InitSceneUI : MonoBehaviour
{
    public event Action OnPlayButtonClickedEvent;

    public Animator arcadeTicketVerme;

    [SerializeField] private GameObject cam;
    [SerializeField] private float lerpSpeed;
    private bool isLook;

    [Header("Settings")]
    private bool isOpenSettingsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject menuPanel;

    [Header("Sound")] [SerializeField] private AudioClip soundTestClip;

    [SerializeField] private TextMeshProUGUI soundText;
    //AudioListener.volume = 1 //Default Volume
    private float soundRate = 0.1f;
    private float soundVolume;

    private void Start()
    {
        soundVolume = 0.3f;
        isOpenSettingsPanel = false;
        settingsPanel.SetActive(false);
    }

    public void IlkSahneyiYukle()
    {
        OnPlayButtonClickedEvent?.Invoke();
        PlayerPrefs.SetInt("LastPosInt",0);
        StartCoroutine(LoadScene(1));
    }

    public void SettingPanel()
    {
        if (isOpenSettingsPanel)
        {
            isOpenSettingsPanel = false;
            menuPanel.SetActive(true);
            settingsPanel.SetActive(false);
        }
        else
        {
            isOpenSettingsPanel = true;
            menuPanel.SetActive(false);
            settingsPanel.SetActive(true);
        }
    }

    private void AddSoundText()
    {
        soundVolume = Mathf.Clamp01(soundVolume);
        SoundManager.instance.PlaySoundEffect(soundTestClip);
        
        var temp = (int)(soundVolume * 10) % 11;

        soundText.text = "";
        for (int i = 0; i < temp; i++)
        {
            soundText.text += "|";
        }
        AudioListener.volume = soundVolume;
    }

    public void VolumeUP()
    {
        soundVolume += soundRate;
        Debug.Log(AudioListener.volume);
        AddSoundText();
    }

    public void VolumeDown()
    {
        soundVolume -= soundRate;
        Debug.Log(AudioListener.volume);
        AddSoundText();
    }

    IEnumerator LoadScene(int buildIndex)
    {
        yield return new WaitForSeconds(5);
        arcadeTicketVerme.SetTrigger("TicketVer");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(buildIndex);
        yield break;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
