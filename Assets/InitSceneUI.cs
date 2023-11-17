using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitSceneUI : MonoBehaviour
{
    public Animator arcadeTicketVerme;


    public void IlkSahneyiYukle()
    {
        arcadeTicketVerme.SetTrigger("TicketVer");
        StartCoroutine(LoadScene(1));
    }

    IEnumerator LoadScene(int buildIndex)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(buildIndex);
        yield break;
    }
}
