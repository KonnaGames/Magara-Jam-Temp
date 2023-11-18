using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [SerializeField] private Transform[] transformPoints;
    [SerializeField] private Transform mouthPoint;
    [SerializeField] private Transform projectilePrefab;
    [SerializeField] private float speed;

    private int currentPoint;

    private void Start()
    {
        currentPoint = 0;
    }
    void Update()
    {
        if (transform.position != transformPoints[currentPoint].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, transformPoints[currentPoint].position, speed * Time.deltaTime);
        }
        else
        {
            currentPoint = (currentPoint + 1) % transformPoints.Length;
        }
    }
    private void Shoot()
    {

    }
}
