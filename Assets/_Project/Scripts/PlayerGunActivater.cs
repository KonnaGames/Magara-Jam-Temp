using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunActivater : MonoBehaviour
{
    [SerializeField] private bool isActive;
    [SerializeField] private Transform shotgun;
    void Update()
    {
        if (isActive)
        {
            shotgun.gameObject.SetActive(true);
        }
        else
        {
            shotgun.gameObject.SetActive(false);
        }
    }
}
