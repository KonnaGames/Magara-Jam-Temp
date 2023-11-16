using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BirDCharacterController : MonoBehaviour, IDamagable
{
    private InputManager _inputManager;
    private RangeBehaviour _rangeBehaviour;
    private Rigidbody2D rb2D;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxVel;

    public ParticleSystem ParticleSystem;

    public bool lockMovement = false;



    private void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _rangeBehaviour = GetComponentInChildren<RangeBehaviour>();
        rb2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (_inputManager.GetSpaceButtonPressed)
        {
            _rangeBehaviour.DestroyRangeEnemies();
        }
    }


    private void FixedUpdate()
    {
        MoveHandle();
    }


    private void MoveHandle()
    {
        if (lockMovement) return;
        
        // Vector2 transformPos = transform.position;
        // var nextPos = transformPos + (_inputManager.Get1DMovement * moveSpeed * Time.deltaTime);
        // transform.position = nextPos;
        
        rb2D.AddForce(_inputManager.Get1DMovement * moveSpeed, ForceMode2D.Force);
        if (Mathf.Abs(rb2D.velocity.x)  > maxVel)
        {
            Vector3 vel = rb2D.velocity;
            rb2D.velocity = new Vector2(vel.x > 0 ? maxVel : -maxVel, vel.y);
        }
    }

    public void TakeDamage()
    {
        Debug.Log("TakeDamage");
        ParticleSystem.Play();
    }
}
