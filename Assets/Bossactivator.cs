using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossactivator : MonoBehaviour
{
    public GameObject boss;
    public void BossActivator(bool activate)
    {
        boss.SetActive(activate);
    }
}
