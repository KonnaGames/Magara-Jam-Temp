using System;
using UnityEngine;

public class BirDCameraScr : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        var targetPos = new Vector3(target.position.x, transform.position.y, transform.position.z);

        Vector3 vel = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, 12.5f * Time.deltaTime);
    }
}
