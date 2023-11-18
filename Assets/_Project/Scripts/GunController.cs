using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletPrefabRight;
    [SerializeField] private Transform  shootPoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform cross;
    [SerializeField] private LayerMask layer;

    private bool canShoot = true;
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && canShoot)
        {
            canShoot = false;
            Shoot();
            StartCoroutine(ShootLimiter());
        }
        if (Input.GetMouseButton(1) && canShoot)
        {
            canShoot = false;
            ShootRight();
            StartCoroutine(ShootLimiter());
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        Ray ray = Camera.main.ScreenPointToRay(cross.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 300, layer))
        {
            Vector3 direction = hit.point - shootPoint.position;
            direction.Normalize();

            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);
            Destroy(bullet, 1);
        }
    }
    private IEnumerator ShootLimiter()
    {
        yield return new WaitForSeconds(1f);

        canShoot = true;
    }
    private void ShootRight()
    {
        GameObject bulletRight = Instantiate(bulletPrefabRight, shootPoint.position, shootPoint.rotation);
        Ray ray = Camera.main.ScreenPointToRay(cross.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 300, layer))
        {
            Vector3 direction = hit.point - shootPoint.position;
            direction.Normalize();

            bulletRight.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);
            Destroy(bulletRight, 1);
        }
    }
}
