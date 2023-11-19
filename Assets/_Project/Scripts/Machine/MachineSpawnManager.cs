using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _arcadeMachineBolum1;
    [SerializeField] private GameObject _arcadeMachineBolum2;
    [SerializeField] private GameObject _arcadeMachineBolum3;

    private void Awake()
    {
        SpawnMachine();
        print(PlayerSpawnManager.instance.lastPosInt);
    }


    private void SpawnMachine()
    {
        switch (PlayerSpawnManager.instance.lastPosInt)
        {
            case 0:
                _arcadeMachineBolum1.SetActive(true); 
                break;
            case 1:
                _arcadeMachineBolum2.SetActive(true);
                break;
            case 2:
                _arcadeMachineBolum3.SetActive(true);
                break;
            default:
                break;
        }
    }
}
