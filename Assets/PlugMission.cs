using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlugMission : MonoBehaviour
{
    public static PlugMission _instance;

    [SerializeField] private TextMeshProUGUI _missionText;
    [SerializeField] private AlarmController _alarmController;
    [SerializeField] private Plug _plug;
    [SerializeField] private CreditsUI _creditsUI;

    public static PlugMission Instance => _instance;

    private void OnEnable()
    {
        _plug.OnPlugPulledEvent += OnPlugPulled;
    }

    private void OnPlugPulled()
    {
        //Dialog görünsün ve credits gelsin
        _creditsUI.gameObject.SetActive(true);
        _creditsUI.ShowCredits();

        FindObjectOfType<PlayerMovement3D>().StopMoving();
        FindObjectOfType<GunController>().StopShooting();
    }

    private void Awake()
    {
        if(_instance == null)
            _instance = this;
    }

    void Start()
    {
        
    }

    public void StartMission()
    {
        _missionText.gameObject.SetActive(true);
        _alarmController.SetAlarmsOn();
    }

}
