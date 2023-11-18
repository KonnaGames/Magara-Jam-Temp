using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealhtSystem : MonoBehaviour
{
    public static PlayerHealhtSystem Instance { get; set; }

    [SerializeField] private bool canDamaged;
    [SerializeField] private Transform BossProjectileVFX;
    [SerializeField] private Transform ghostExplodeVFX;
    [SerializeField] private AudioClip deathSound;

    private int playerHealht;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        playerHealht = 3;
        canDamaged = true;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DotProjectile")
        {
            Instantiate(BossProjectileVFX, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            if (canDamaged)
            {
                Damaged();
            }
        }
        if (col.gameObject.tag == "Ghost")
        {
            Instantiate(ghostExplodeVFX, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            if (canDamaged)
            {
                Damaged();
            }
        }
    }
    private void Damaged()
    {
        CameraShake3D.Shake(0.3f, 1f);

        canDamaged = false;
        StartCoroutine(CantTakeDamage());
        playerHealht -= 1;
        if (playerHealht <= 0)
        {
            RestartGame();
        }
    }
    private IEnumerator CantTakeDamage()
    {
        yield return new WaitForSeconds(2);

        canDamaged = true;
    }
    private void RestartGame()
    {
        PlayerGunActivater.Instance.SetIsGunActive(false);
        SoundManager.instance.PlaySoundEffect(deathSound);
        StartCoroutine(RestartingScene());
    }
    public int GetHealth()
    {
        return playerHealht;
    }
    private IEnumerator RestartingScene()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(5);
    }
}
