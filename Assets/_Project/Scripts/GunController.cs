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
    [SerializeField] private AudioClip fireAudio;
    [SerializeField] private Animation recoilAnim;

    private bool canShoot = true;

    private void Update()
    {
        if (Input.GetMouseButton(0) && canShoot)
        {
            canShoot = false;
            Shoot();
            StartCoroutine(ShootLimiter());
        }
    }
    void Shoot()
    {
        CameraShake3D.Shake(0.5f, 0.4f);
        GunRecoil();

        SoundManager.instance.PlaySoundEffect(fireAudio);

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
        yield return new WaitForSeconds(0.5f);

        canShoot = true;
    }

    public void StopShooting()
    {
        canShoot = false;
    }
    private void GunRecoil()
    {
        recoilAnim.Play();
    }
}
