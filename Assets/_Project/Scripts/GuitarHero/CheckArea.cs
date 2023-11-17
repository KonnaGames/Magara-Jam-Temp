using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckArea : MonoBehaviour
{
    private event Action<Box> _onBoxEntered;
    private event Action<Box> _onBoxExited;

    public void SubscribeEvents(Action<Box> onBoxEntered,Action<Box> onBoxExited)
    {
        _onBoxEntered -= onBoxEntered;
        _onBoxExited -= onBoxExited;

        _onBoxEntered += onBoxEntered;
        _onBoxExited += onBoxExited;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _onBoxEntered?.Invoke(collision.GetComponent<Box>());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _onBoxExited?.Invoke(collision.GetComponent<Box>());
    }

}
