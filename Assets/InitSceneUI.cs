using System;
using System.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using TMPro;

public class InitSceneUI : MonoBehaviour
{
    public Animator arcadeTicketVerme;

    [SerializeField] private GameObject cam;
    [SerializeField] Quaternion camSecondPos;
    [SerializeField] private float lerpSpeed;
    private bool isLook;

    [Header("Settings")]
    private bool isOpenSettingsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject menuPanel;

    [Header("Sound")]

    [SerializeField] private TextMeshProUGUI soundText;
    //AudioListener.volume = 1 //Default Volume
    private float soundRate = 0.1f;
    private float soundVolume;

    private void Start()
    {
        soundVolume = 0.5f;
        isOpenSettingsPanel = false;
        settingsPanel.SetActive(false);
    }
    private void Update()
    {
        if (isLook)
        {
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, camSecondPos, lerpSpeed * Time.deltaTime);
        }
    }

    public void IlkSahneyiYukle()
    {
        isLook = true;
        arcadeTicketVerme.SetTrigger("TicketVer");
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
        if (soundVolume > 1)
        {
            soundVolume = 1;
        }
        if (soundVolume < 0)
        {
            soundVolume = 0;
        }
        soundText.text = "";
        for (int i = 0; i < soundVolume * 10; i++)
        {
            soundText.text += "|";
        }
       
        AudioListener.volume = soundVolume;
    }

    public void VolumeUP()
    {
        if (soundVolume <= 1 && soundVolume >= 0)
        {
            soundVolume += soundRate;
            Debug.Log(AudioListener.volume);
            AddSoundText();
        }
    }

    public void VolumeDown()
    {
        if (soundVolume <= 1 && soundVolume >= 0)
        {
            soundVolume -= soundRate;
            AudioListener.volume = soundVolume;
            Debug.Log(AudioListener.volume);
            AddSoundText();
        }
    }

    IEnumerator LoadScene(int buildIndex)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(buildIndex);
        yield break;
    }
}
