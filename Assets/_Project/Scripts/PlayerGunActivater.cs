using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunActivater : MonoBehaviour
{
    public static PlayerGunActivater Instance { get; set; }

    [SerializeField] private Transform shotgun;

    public bool isActive;

    private void Awake()
    {
        Instance = this;
    }
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
    public bool GetIsGunActive()
    {
        return isActive;
    }
    public void SetIsGunActive(bool isGunActive)
    {
        isActive = isGunActive;
    }
}
