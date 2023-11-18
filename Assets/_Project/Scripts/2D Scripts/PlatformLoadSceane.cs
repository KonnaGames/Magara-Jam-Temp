using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLoadSceane : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadingScreen.instance.LoadScene(1);
    }
}
