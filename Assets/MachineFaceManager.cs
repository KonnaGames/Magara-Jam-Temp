using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineFaceManager : MonoBehaviour
{
    public static MachineFaceManager _instance;

    [SerializeField] private SpriteRenderer _mouth;


    private void Awake()
    {
        if(_instance == null)
            _instance = this;

    }

    public static void StartTalking()
    {
        _instance._mouth.GetComponent<Animator>().SetBool("isTalking", true);
    }

    public static void StopTalking()
    {
        _instance._mouth.GetComponent<Animator>().SetBool("isTalking", false);
    }

}
