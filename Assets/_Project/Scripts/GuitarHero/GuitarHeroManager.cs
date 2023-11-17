using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GuitarHeroManager : MonoBehaviour
{
    [SerializeField] private List<SpawnPlace> _spawnPlaces;
    [SerializeField] private BoxFactory _boxFactory;

    [Header("Settings")]
    [SerializeField] private Settings _settings;

    private bool _isSpawning = false;

    void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        _isSpawning = true;
        StartCoroutine(IE_Spawning());
    }

    private IEnumerator IE_Spawning()
    {
        while (_isSpawning)
        {
            Box box = _boxFactory.Create();

            SpawnPlace spawnPlace = _spawnPlaces[Random.Range(0, _spawnPlaces.Count)];

            Vector3 position = spawnPlace.Position.transform.position;
            box.Initialize(_settings.BoxSpeed,spawnPlace, _settings.BoxMoveDirection, PushBox);

            box.StartMove();

            yield return new WaitForSeconds(_settings.SpawnRate);
        }
    }


    private void PushBox(Box box)
    {
        _boxFactory.Push(box);
    }


    [Serializable]
    public struct Settings
    {
        public Vector3 BoxMoveDirection;
        public float BoxSpeed;
        public float SpawnRate;
    }

    [Serializable]
    public struct SpawnPlace
    {
        public Direction Direction;
        public Transform Position;
        public Color Color;
    }

}
