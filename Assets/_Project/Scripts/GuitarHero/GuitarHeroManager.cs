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
    public GameObject canvas;

    [SerializeField] private int _heartCount = 3;
    [SerializeField] private int _score = 0;

    [Header("Settings")]
    [SerializeField] private Settings _settings;

    [Header("Sound Settings")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private SoundSettings _soundSettings;

    private bool _isSpawning = false;
    private bool _isGameFinished = false;

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
        if (_isGameFinished)
            return;

            
        _heartCount--;
        GuitarHeroViewManager.Instance.RemoveHeart();
        DialogueManage.instance.StartCustomDialogue();

        if (_heartCount <= 0)
        {
            Failed();
            print("Failed");
        }
    }

    public void OnGainScore()
    {
        if (_isGameFinished)
            return;

        _score++;
        GuitarHeroViewManager.Instance.SetScore(_score);
        _settings.BoxSpeed += _settings.SpeedMultiplier;
        _settings.SpawnRate -= _settings.RateMultiplier;

        SoundManager.instance.PlaySoundEffect(_soundSettings.GainScoreClip);

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
        _isGameFinished = true;
        _audioSource.Stop();
        canvas.SetActive(false);
        LoadingScreen.instance.LoadScene(1);
    }

    [Serializable]
    public struct Settings
    {
        public Vector3 BoxMoveDirection;
        public float BoxSpeed;
        public float SpawnRate;
        public int SuccessScore;
        public float SpeedMultiplier;
        public float RateMultiplier;
    }

    [Serializable]
    public struct SoundSettings
    {
        public AudioClip GainScoreClip;
    }

    [Serializable]
    public struct SpawnPlace
    {
        public Direction Direction;
        public Transform Position;
        public Color Color;
    }

}
