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
    
    private void Start()
    {
        Debug.Log("Player Spawn Start Calisti");
        lastPosInt = PlayerPrefs.GetInt("LastPosInt");
        Debug.Log(lastPosInt + " +++");
    }

    public Vector3 SetPlayerPositionBySpawnPoints()
    {
        // if (lastPosInt > SpawnPoints.Count - 1) return SpawnPoints[lastPosInt - 1].position;
        Debug.Log(SpawnPoints[lastPosInt].position);
        return SpawnPoints[lastPosInt].position;
    }

    public void SpawnPointArttir()
    {
        Debug.Log("Spawn Arttir Test");
        lastPosInt = PlayerPrefs.GetInt("LastPosInt");
        lastPosInt++;
        PlayerPrefs.SetInt("LastPosInt", lastPosInt);
        
        Debug.Log(lastPosInt + " last Pos");
        Debug.Log(PlayerPrefs.GetInt("LastPosInt") + " saved one");
    }

    [ContextMenu("RestartSpawnPos")]
    public void RestartSpawnPos()
    {
        lastPosInt = 0;
        PlayerPrefs.SetInt("LastPosInt",lastPosInt);
    }
}
