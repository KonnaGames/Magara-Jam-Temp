using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen instance;

    public TextMeshProUGUI text;

    // public Image arkaPanel;
    public RawImage videoPanel;
    public VideoPlayer VideoPlayer;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if(instance != this) Destroy(this.gameObject);
        
        DontDestroyOnLoad(this);
        
        
        text.transform.gameObject.SetActive(false);
    }

    
    public void LoadScene(string dialogue, int sceneBuildIndex)
    {
        text.text = dialogue;
        StartCoroutine(StartFadeEffectCo(1));
    }
    
    public void LoadScene(int sceneBuildIndex)
    {
        StartCoroutine(StartFadeEffectCo(1));
    }

    
    [ContextMenu("test")]
    public void Test()
    {
        StartCoroutine(StartFadeEffectCo(1));

    }


    IEnumerator StartFadeEffectCo(int sceneBuildIndex)
    {
        VideoPlayer.Play();
        // Debug.Log(arkaPanel.color.a);
        Color color = videoPanel.color;

        float vel = 1;
        while (videoPanel.color.a <= 0.99f)
        {
            color = videoPanel.color;
            color.a = Mathf.SmoothDamp(color.a, 1, ref vel, 1);
            videoPanel.color = color;
            // videoPanel.color = color;
            yield return new WaitForFixedUpdate();
        }

        color = videoPanel.color;
        videoPanel.color = new Color(color.r, color.g, color.b, 1);
        // videoPanel.color = videoPanel.color;
        SceneManager.LoadScene(sceneBuildIndex);
        
        text.transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        text.transform.gameObject.SetActive(false);
        text.text = "";

        while (videoPanel.color.a > 0.01f)
        {
            color = videoPanel.color;
            color.a = Mathf.SmoothDamp(color.a, 0, ref vel, 1);
            videoPanel.color = color;
            // videoPanel.color = color;

            yield return new WaitForFixedUpdate();
        }
        
        color = videoPanel.color;
        videoPanel.color = new Color(color.r, color.g, color.b, 0);
        // videoPanel.color = videoPanel.color;
        VideoPlayer.Stop();

        
        yield break;
    }
}
