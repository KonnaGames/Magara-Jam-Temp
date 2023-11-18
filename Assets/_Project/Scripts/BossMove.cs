using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public static BossMove Instance { get; set;}

    [SerializeField] private Animator animator;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform[] transformPoints;
    [SerializeField] private Transform mouthPoint;
    [SerializeField] private Transform projectilePrefab;
    [SerializeField] private Transform bulletVfx;
    [SerializeField] private float speed;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private int health = 100;


    private int currentPoint;
    private int healthMax = 100;
    private bool canShoot = true;
    private bool intantiateAllowed = false;

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

        Instantiate(projectilePrefab, mouthPoint.position, mouthPoint.rotation);       
    }
    private IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(3);

        canShoot = true;
    }
    private IEnumerator AnimationDelay()
    {
        yield return new WaitForSeconds(1);

        intantiateAllowed = true;
    }
}
