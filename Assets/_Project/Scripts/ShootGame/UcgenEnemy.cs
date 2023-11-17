using System;
using Unity.Mathematics;
using UnityEngine;

public class Enemy1 : MonoBehaviour, IDamagable
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private GameObject Effect;

    public static event Action OnStarDeath;
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
        var temp = Instantiate(Effect, transform.position, quaternion.identity);
        Destroy(temp,3f);
        OnStarDeath?.Invoke();
        Debug.Log("Enemy Dead");
        Destroy(this.gameObject);
    }
}
