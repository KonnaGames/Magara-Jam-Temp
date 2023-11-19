using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    [SerializeField] private ButtonHoverSettings _buttonHoverSettings;

    [SerializeField] private List<MenuButton> _menuButtons;


    private void Awake()
    {
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].Initialize(_buttonHoverSettings);
        }
    }

}


[Serializable]
public struct ButtonHoverSettings
{
    public Vector3 TargetScale;
    public float Duration;
}
