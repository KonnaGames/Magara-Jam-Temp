using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen instance;

    public TextMeshProUGUI text;

    public Image arkaPanel;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if(instance != this) Destroy(this.gameObject);
        
        DontDestroyOnLoad(this);
    }


    
    public void LoadScene(string dialogue, int sceneBuildIndex)
    {
        text.text = dialogue;
        SceneManager.LoadScene(sceneBuildIndex);
        StartCoroutine(StartFadeEffectCo());
    }

    [ContextMenu("Test")]
    public void Test()
    {
        StartCoroutine(StartFadeEffectCo());

    }

    IEnumerator StartFadeEffectCo()
    {
        Debug.Log(arkaPanel.color.a);
        Color color = arkaPanel.color;

        float vel = 1;
        while (arkaPanel.color.a <= 0.99f)
        {
            color = arkaPanel.color;
            color.a = Mathf.SmoothDamp(color.a, 1, ref vel, 1);
            arkaPanel.color = color;
            yield return new WaitForFixedUpdate();
        }

        color = arkaPanel.color;
        arkaPanel.color = new Color(color.r, color.g, color.b, 1);
        
        yield return new WaitForSeconds(3f);

        while (arkaPanel.color.a > 0.01f)
        {
            color = arkaPanel.color;
            color.a = Mathf.SmoothDamp(color.a, 0, ref vel, 1);
            arkaPanel.color = color;
            yield return new WaitForFixedUpdate();
        }
        
        color = arkaPanel.color;
        arkaPanel.color = new Color(color.r, color.g, color.b, 0);

        
        yield break;
    }
}
