using UnityEngine;

public class AlarmActiavotr : MonoBehaviour
{
    public GameObject alarm;

    public void AlarmActivator(bool activate)
    {
        alarm.SetActive(activate);
    }
}
