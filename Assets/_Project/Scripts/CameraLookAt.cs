using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private void Awake()
    {
        
    }

    private void LateUpdate()
    {
        transform.LookAt(playerTransform);
    }

}
