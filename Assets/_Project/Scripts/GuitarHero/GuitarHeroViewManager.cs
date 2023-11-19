using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuitarHeroViewManager : MonoBehaviour
{
    private static GuitarHeroViewManager _instance;

    public static GuitarHeroViewManager Instance => _instance;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private List<GameObject> _hearts;
    [SerializeField] private GameObject _tutorial;

    private void Awake()
    {
        _instance = this;

        Invoke(nameof(HideTutorial), 3);
    }

    public void SetScore(int score)
    {
        _scoreText.text = score.ToString();
    }

    public void RemoveHeart()
    {
        int lastIndex = _hearts.Count - 1;
        _hearts[lastIndex].gameObject.SetActive(false);
        _hearts.RemoveAt(lastIndex);
    }

    private void HideTutorial()
    {
        _tutorial.gameObject.SetActive(false);
    }

}
