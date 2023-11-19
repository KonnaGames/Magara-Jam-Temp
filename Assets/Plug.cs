using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug : MonoBehaviour,IInteractable
{
    public event Action OnPlugPulledEvent;

    [SerializeField] private string _interactText;
    [SerializeField] private Animation _animation;

    public string interactionName { get; private set; }
    public bool isInteracted { get; private set; }

    private void Start()
    {
        isInteracted = true;
    }

    public void Interact()
    {
        _animation.Play();
        OnPlugPulledEvent?.Invoke();
        isInteracted = true;
    }


    private void Awake()
    {
        interactionName = _interactText;
    }

    public void InteractAc()
    {
        isInteracted = false;
    }

}
