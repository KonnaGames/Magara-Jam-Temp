using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerController : MonoBehaviour
{
    private bool isMoveing;
    private Animator _animator;

    private Vector2 playerTransform;
    private RaycastHit2D hit;
    private float distance;

    [SerializeField] private LayerMask wallMask;
    [SerializeField] private float lerpTime = 5f;
    [SerializeField] private Vector2 moveDirection = Vector2.zero;
    
    Vector2 nextPos = Vector2.one;

    [SerializeField] private SpriteRenderer body;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Material tailMaterial;
    
    private int colorID;

    private AudioSource audioSource;
    [SerializeField] private AudioClip jumpEffect;
    [SerializeField] private AudioClip pickKeyEffect;
    [SerializeField] private AudioClip doorOpenEffect;

    private void Start()
    {
        colorID = 0;
        transform.position = Vector3.zero;
        playerTransform = transform.position;
        isMoveing = true;

        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        tailMaterial.color = Color.white;
    }

    private void Update()
    {
        MoveDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("key"))
        {
            audioSource.PlayOneShot(pickKeyEffect);
            body.color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            colorID = collision.gameObject.GetComponent<Keys>().keyId;
            _particleSystem.startColor = body.color;
            tailMaterial.color = body.color;
            _particleSystem.Play();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("door"))
        {
            if (colorID == collision.gameObject.GetComponent<Door>().doorId)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("door"))
        {
            if (colorID == collision.gameObject.GetComponent<Door>().doorId)
            {
                audioSource.PlayOneShot(doorOpenEffect);
                _particleSystem.Play();
                Destroy(collision.collider.gameObject);
            }
        }
    }

    private void MoveDirection()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !isMoveing)
        {
            audioSource.PlayOneShot(jumpEffect);
            moveDirection = new Vector2(0, 1);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !isMoveing)
        {
            audioSource.PlayOneShot(jumpEffect);
            moveDirection = new Vector2(0, -1);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !isMoveing)
        {
            audioSource.PlayOneShot(jumpEffect);
            moveDirection = new Vector2(-1, 0);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !isMoveing)
        {
            audioSource.PlayOneShot(jumpEffect);
            moveDirection = new Vector2(1, 0);
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        Move(moveDirection);
    }

    private void Move(Vector2 moveDirection)
    {
        isMoveing = true;
        _animator.SetBool("isMoving", true);
        var controlResult = DistanceControl(moveDirection);

        Vector2 move = controlResult.Item1;
        float dis = controlResult.Item2;

        nextPos.x = playerTransform.x + (dis * move.x);
        nextPos.y = playerTransform.y + (dis * move.y);

        transform.position = Vector3.MoveTowards(transform.position, nextPos, lerpTime * Time.deltaTime);
       
        Vector2 posControl = transform.position;
        if (Vector2.Distance(posControl,nextPos) < 0.001f)
        {
            isMoveing = false;
            _animator.SetBool("isMoving", false);
            playerTransform = transform.position;
        }
    }

    private (Vector2, float) DistanceControl(Vector2 moveDirection)
    {
        if (moveDirection != Vector2.zero)
        {
            hit = Physics2D.Raycast(playerTransform, moveDirection, Mathf.Infinity, wallMask);

            if (hit.collider != null)
            {
                OpenTheDoor(hit);
                Vector2 targetPos = hit.collider.gameObject.transform.position;
                distance = Vector2.Distance(playerTransform, targetPos) - 1;
                return (moveDirection, distance);
            }
        }
        return (moveDirection, 0);
    }

    private void OpenTheDoor(RaycastHit2D hit)
    {
        if (hit.collider.gameObject.CompareTag("door"))
        {
            if(colorID == hit.collider.gameObject.GetComponent<Door>().doorId)
            {
                audioSource.PlayOneShot(doorOpenEffect);
                hit.collider.gameObject.layer = default;
                hit.collider.gameObject.GetComponent<Collider2D>().isTrigger = true;            
            }
        }
    }
}
