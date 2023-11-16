using UnityEngine;

public class BirDCharacterController : MonoBehaviour, IDamagable
{
    private InputManager _inputManager;
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        _inputManager = GetComponent<InputManager>();
    }


    
    
    private void FixedUpdate()
    {
        MoveHandle();
    }


    private void MoveHandle()
    {
        Vector2 transformPos = transform.position;
        var nextPos = transformPos + (_inputManager.Get1DMovement * moveSpeed * Time.deltaTime);
        transform.position = nextPos;
    }

    public void TakeDamage()
    {
        Debug.Log("TakeDamage");
    }
}
