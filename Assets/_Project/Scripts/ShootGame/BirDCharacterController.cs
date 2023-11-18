using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirDCharacterController : MonoBehaviour, IDamagable
{
    private InputManager _inputManager;
    private Rigidbody2D rb2D;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxVel;

    public ParticleSystem ParticleSystem;
    public AudioClip laserShoot;

    public Transform spawnPoint;
    public GameObject BulletPrefab;
    private float time = 0;
    private float timer = 0.15f;

    private void Start()
    {
        _inputManager = GetComponent<InputManager>();
        rb2D = GetComponent<Rigidbody2D>();

    }


    private void Update()
    {
        Shoot();
        CheckCorner();
    }

    private void CheckCorner()
    {
        if (transform.position.x < -10) transform.position = new Vector3(10, transform.position.y);
        else if (transform.position.x > 10) transform.position = new Vector3(-10, transform.position.y);
    }

    private void Shoot()
    {
        time += Time.deltaTime;
        if (_inputManager.GetSpaceButtonPressed && time >= timer)
        {
            SoundManager.instance.PlaySoundEffect(laserShoot);
            Instantiate(BulletPrefab, spawnPoint.position, quaternion.identity);
            time = 0;
        }
    }


    private void FixedUpdate()
    {
        MoveHandle();
    }


    private void MoveHandle()
    {
        rb2D.AddForce(_inputManager.Get1DMovement * moveSpeed, ForceMode2D.Force);
        if (Mathf.Abs(rb2D.velocity.x)  > maxVel)
        {
            Vector3 vel = rb2D.velocity;
            rb2D.velocity = new Vector2(vel.x > 0 ? maxVel : -maxVel, vel.y);
        }
    }

    public void TakeDamage()
    {
        ParticleSystem.Play();
        
        DialogueManage.instance.StartCustomDialogue();
        
        Invoke(nameof(RestartScene), 0.5f);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
