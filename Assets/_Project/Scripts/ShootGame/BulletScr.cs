using System;
using UnityEngine;

namespace _Project.Scripts.ShootGame
{
    public class BulletScr : MonoBehaviour
    {
        public float speed;


        private void Update()
        {
            if(transform.position.y > 10) Destroy(this.gameObject);
        }

        private void FixedUpdate()
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeDamage();
                Destroy(this.gameObject);
            }
        }
    }
}