using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int score;

    public bool isWarping;

    private void Start()
    {
        score = 20;
        text.text = score.ToString() + " Yıldız Patlat";
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
        if (isWarping) return;
        
        score--;
        text.text = "Collect " + score.ToString() + " Stars";
        if (score == 0)
        {
            isWarping = true;
            transform.gameObject.SetActive(false);
            LoadingScreen.instance.LoadMainMenu();
        }
    }
}
