using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlatformLoadSceane : MonoBehaviour
{

    private void Update()
    {
        RestartScene();
    }
    private void RestartScene()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(4);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadingScreen.instance.LoadScene(1);
    }
}
