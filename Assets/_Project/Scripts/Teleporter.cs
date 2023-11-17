using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public static Teleporter Instance { get; set; }

    [SerializeField] private Transform arcadeMachine;

    public bool TeleportCheck1 = false;
    public bool TeleportCheck2 = false;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (TeleportCheck1 == true)
        {
            TeleportStageOne();
            TeleportCheck1 = false;
        }
        else if(TeleportCheck2 == true)
        {
            TeleportStageTwo();
            TeleportCheck2 = false;
        }
    }
    private void TeleportStageOne()
    {
        arcadeMachine.position += new Vector3(0, 0, -15);
    }
    private void TeleportStageTwo()
    {
        arcadeMachine.position += new Vector3(0, 0, -15);
    }
}
