using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    [SerializeField] private List<Light> _alarms;
    [SerializeField] private AlarmSettings _alarmSettings;


    private void Start()
    {
        SetAlarmsOn();
    }
    public void SetAlarmsOn()
    {
        for (int i = 0; i < _alarms.Count; i++)
        {
            Tweener lightOn = _alarms[i].DOIntensity(_alarmSettings.MaxIntensity, _alarmSettings.Duration);
            Tweener lightOff = _alarms[i].DOIntensity(0, _alarmSettings.Duration);

            Sequence sequence = DOTween.Sequence();
            sequence.Append(lightOn);
            sequence.Append(lightOff);

            sequence.SetLoops(-1);
        }


    }


    [Serializable]
    public struct AlarmSettings
    {
        public float MaxIntensity;
        public float Duration;
    }

}
