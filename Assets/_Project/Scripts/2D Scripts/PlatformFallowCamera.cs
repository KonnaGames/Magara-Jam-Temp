using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallowCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float fallowSpeed;
    [SerializeField] private Vector3 distance;


    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, playerTransform.position + distance, fallowSpeed * Time.deltaTime);    
    }
}
