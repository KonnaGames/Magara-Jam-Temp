using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public static BossMove Instance { get; set;}

    [SerializeField] private Animator animator;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform[] transformPoints;
    [SerializeField] private Transform bulletVfx;
    [SerializeField] private Transform ghostPoint1;
    [SerializeField] private Transform ghostPoint2;
    [SerializeField] private Transform ghostPrefab;
    [SerializeField] private float speed;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private int health = 100;


    private int currentPoint;
    private int healthMax = 100;
    private bool canShoot = true;
    private bool canSpawn = true;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        currentPoint = 0;
    }
    void Update()
    {
        if (health <= 50)
        {
            StageTwo();
        }
        if (canShoot)
        {
            Shoot();
            StartCoroutine(ShootTimer());
            canShoot = false;
        }
        if (transform.position != transformPoints[currentPoint].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, transformPoints[currentPoint].position, speed * Time.deltaTime);
        }
        else
        {
            currentPoint = (currentPoint + 1) % transformPoints.Length;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Instantiate(bulletVfx, col.transform.position, Quaternion.identity);

            Damage();
            Destroy(col.gameObject);
        }
    }
    private void Damage()
    {
        health -= 10;
    }
    public float GetHealthNormalized()
    {
        return (float)health / healthMax;
    }
    private void Shoot()
    {        
        animator.SetTrigger("Shoot");     
    }
    private IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(3);

        canShoot = true;
    }
    private void StageTwo()
    {
        speed = 12;
        if (canSpawn)
        {
            Debug.Log("StageTwo");
            canSpawn = false;
            StartCoroutine(SpawnGhosts());
        }
    }
    private IEnumerator SpawnGhosts()
    {
        Instantiate(ghostPrefab, ghostPoint1.position, Quaternion.identity);
        Instantiate(ghostPrefab, ghostPoint2.position, Quaternion.identity);

        yield return new WaitForSeconds(10);

        canSpawn = true;
    }
}
