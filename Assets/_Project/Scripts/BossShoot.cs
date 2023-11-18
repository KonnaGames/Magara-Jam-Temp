using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{

    [SerializeField] private Transform projectilePrefab;
    [SerializeField] private Transform mouthPoint;


    public void CreateProjectile()
    {
        Instantiate(projectilePrefab, mouthPoint.position, mouthPoint.rotation);
    }
}
