using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuButton : MonoBehaviour
{
    private ButtonHoverSettings _buttonHoverSettings;

    private Button _button;

    private Vector3 _startScale;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _startScale = _button.transform.localScale;
    }

    public void Initialize(ButtonHoverSettings buttonHoverSettings)
    {
        _buttonHoverSettings = buttonHoverSettings;
    }

    public void OnPointerEnter()
    {
        _button.transform.DOScale(_buttonHoverSettings.TargetScale, _buttonHoverSettings.Duration);
    }

    public void OnPointerExit()
    {
        _button.transform.DOScale(_startScale, _buttonHoverSettings.Duration);
    }

    public void CompleteTween()
    {
        _button.transform.localScale = _startScale;
    }


}
