using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform ghostExplodeVFX;

    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (PlayerHealhtSystem.Instance.GetHealth() > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Instantiate(ghostExplodeVFX, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            Instantiate(ghostExplodeVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
