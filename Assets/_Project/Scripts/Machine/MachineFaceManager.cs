using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineFaceManager : MonoBehaviour
{
    public static MachineFaceManager _instance;

    [SerializeField] private Animator _mouthAnimator;


    private void Awake()
    {
        if(_instance == null)
            _instance = this;

    }

    public static void StartTalking()
    {
        if(_instance != null)
            _instance._mouthAnimator.SetBool("isTalking", true);
    }

    public static void StopTalking()
    {
        if (_instance != null)
            _instance._mouthAnimator.SetBool("isTalking", false);
    }

}
