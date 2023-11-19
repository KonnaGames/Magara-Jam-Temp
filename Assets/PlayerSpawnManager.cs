using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public static PlayerSpawnManager instance;
    
    
    [SerializeField] private List<Transform> SpawnPoints;
    public int lastPosInt;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if(instance != this) Destroy(this.gameObject);
        
        DontDestroyOnLoad(this.gameObject);
    }
    
    public Vector3 SetPlayerPositionBySpawnPoints()
    {
        print("Dönen Pos: " + SpawnPoints[lastPosInt].position);
        return SpawnPoints[lastPosInt].position;
    }

    public void SpawnPointArttir()
    {
        lastPosInt++;
    }

    [ContextMenu("RestartSpawnPos")]
    public void RestartSpawnPos()
    {
        lastPosInt = 0;
    }
}
