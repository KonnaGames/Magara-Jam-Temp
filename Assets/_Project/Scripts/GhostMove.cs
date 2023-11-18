using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    [SerializeField] private float speed;

    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
