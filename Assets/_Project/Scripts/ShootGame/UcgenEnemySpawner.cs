using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class UcgenEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject UcgenEnemy;
    [SerializeField] private Transform SpawnPosX;
    [SerializeField] private Transform SpawnPosX2;
    [SerializeField] private float spawnRate;

    private bool isPlaying;

    private void Start()
    {
        isPlaying = false;
    }


    private void Update()
    {
        if (isPlaying) return;
        
        if (DialogueManage.instance.currentDialogue >= 9 || DialogueManage.instance.currentDialogue < 5)
        {
            StartSpawning();
            isPlaying = true;
        }
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnerCo());
    }

    IEnumerator SpawnerCo()
    {
        while (true)
        {
            var pos = new Vector2(Random.Range(SpawnPosX.position.x, SpawnPosX2.position.x), 10f );
            var ucgen = Instantiate(UcgenEnemy, pos, quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
