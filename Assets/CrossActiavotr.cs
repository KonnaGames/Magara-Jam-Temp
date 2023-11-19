using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossActiavotr : MonoBehaviour
{
    public GameObject Cross;

    private void Start()
    {
        Cross.SetActive(false);
    }


    public void SetCrossActive()
    {
        Cross.SetActive(true);
    }
}
