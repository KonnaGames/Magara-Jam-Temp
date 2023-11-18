using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealhtSystem : MonoBehaviour
{
    public static PlayerHealhtSystem Instance { get; set; }

    [SerializeField] private int playerHealht = 3;
    [SerializeField] private bool canDamaged = true;
    [SerializeField] private Transform BossProjectileVFX;

    [SerializeField] private AudioClip deathSound;

    private void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DotProjectile")
        {
            Instantiate(BossProjectileVFX, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Dameged();
        }
    }
    private void Dameged()
    {
        canDamaged = false;
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
        SoundManager.instance.PlaySoundEffect(deathSound);
    }
    public int GetHealth()
    {
        return playerHealht;
    }
}
