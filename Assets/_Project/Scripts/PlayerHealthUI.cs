using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Image Heart1;
    [SerializeField] private Image Heart2;
    [SerializeField] private Image Heart3;

    private void Update()
    {
        if (PlayerHealhtSystem.Instance.GetHealth() == 3)
        {
            Heart1.color = Color.red;
            Heart2.color = Color.red;
            Heart3.color = Color.red;
        }
        if (PlayerHealhtSystem.Instance.GetHealth() == 2)
        {
            Heart1.color = Color.white;
            Heart2.color = Color.red;
            Heart3.color = Color.red;
        }
        if (PlayerHealhtSystem.Instance.GetHealth() == 1)
        {
            Heart1.color = Color.white;
            Heart2.color = Color.white;
            Heart3.color = Color.red;
        }
        if (PlayerHealhtSystem.Instance.GetHealth() == 0)
        {
            Heart1.color = Color.white;
            Heart2.color = Color.white;
            Heart3.color = Color.white;
        }
    }
}
