using System;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int score;

    private void Start()
    {
        score = 10;
        text.text = "Collect " + score.ToString() + " Stars";
    }

    private void OnEnable()
    {
        Enemy1.OnStarDeath += UpdateScore;
    }

    private void OnDisable()
    {
        Enemy1.OnStarDeath -= UpdateScore;
    }


    private void UpdateScore()
    {
        score--;
        text.text = "Collect " + score.ToString() + " Stars";
        if(score == 0) LoadingScreen.instance.LoadScene("Bu da neydi Simdi?",0);
    }
}
