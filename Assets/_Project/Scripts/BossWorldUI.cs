using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossWorldUI : MonoBehaviour
{
    [SerializeField] private Image healthBarImage;

    private void Update()
    {
        healthBarImage.fillAmount = BossMove.Instance.GetHealthNormalized();
    }

}
