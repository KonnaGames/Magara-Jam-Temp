using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallowInventory : MonoBehaviour
{
    [SerializeField] private Transform playerTransfom;
    [SerializeField] private float fallowSpeed;
    [SerializeField] private Vector3 distance;

    void Update()
    {
        Vector3 targetPos = playerTransfom.position - distance;
        transform.position = Vector3.Lerp(transform.position, targetPos, fallowSpeed * Time.deltaTime);
    }
}
