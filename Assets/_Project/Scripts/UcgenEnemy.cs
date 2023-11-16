using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour, IDamagable
{
    [SerializeField] private float moveSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        CheckCorners();
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }


    private void CheckCorners()
    {
        if (transform.position.y < -9)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage();
        }
    }
    
    public void TakeDamage()
    {
        Debug.Log("Enemy Dead");
        Destroy(this.gameObject);
    }
}
