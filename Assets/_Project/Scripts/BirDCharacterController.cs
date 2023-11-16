using Unity.VisualScripting;
using UnityEngine;

public class BirDCharacterController : MonoBehaviour, IDamagable
{
    private InputManager _inputManager;
    private RangeBehaviour _rangeBehaviour;
    [SerializeField] private float moveSpeed;

    public bool lockMovement = false;



    private void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _rangeBehaviour = GetComponentInChildren<RangeBehaviour>();
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
        
        Vector2 transformPos = transform.position;
        var nextPos = transformPos + (_inputManager.Get1DMovement * moveSpeed * Time.deltaTime);
        transform.position = nextPos;
    }

    public void TakeDamage()
    {
        Debug.Log("TakeDamage");
    }
}
