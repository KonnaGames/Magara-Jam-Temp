using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GuitarHeroManager : MonoBehaviour
{
    public static event Action OnGameSuccessEvent;

    public static GuitarHeroManager _instance;
    [SerializeField] private List<SpawnPlace> _spawnPlaces;
    [SerializeField] private BoxFactory _boxFactory;

    [SerializeField] private int _heartCount = 3;
    [SerializeField] private int _score = 0;

    [Header("Settings")]
    [SerializeField] private Settings _settings;

    private bool _isSpawning = false;

    public static GuitarHeroManager Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        StartSpawning();
        GuitarHeroViewManager.Instance.SetScore(_score);
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


    //Box en sona ula�t���nda yok olacak o zaman �al��acak
    public void OnBoxDestroyed(Box box)
    {
        _heartCount--;
        GuitarHeroViewManager.Instance.RemoveHeart();

        if (_heartCount <= 0)
        {
            Failed();
            print("Failed");
        }
    }

    public void OnGainScore()
    {
        _score++;
        GuitarHeroViewManager.Instance.SetScore(_score);

        if(_score >= _settings.SuccessScore)
        {
            Success();
        }
    }

    public void Failed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Success()
    {
        LoadingScreen.instance.LoadScene(1);
    }

    [Serializable]
    public struct Settings
    {
        public Vector3 BoxMoveDirection;
        public float BoxSpeed;
        public float SpawnRate;
        public int SuccessScore;
    }

    [Serializable]
    public struct SpawnPlace
    {
        public Direction Direction;
        public Transform Position;
        public Color Color;
    }

}
