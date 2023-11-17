using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformPlayerController : MonoBehaviour
{
    private bool isMoveing;

    private Vector2 playerTransform;
    private RaycastHit2D hit;
    private float distance;

    [SerializeField] private LayerMask wallMask;
    [SerializeField] private float lerpTime = 5f;
    [SerializeField] private Vector2 moveDirection = Vector2.zero;
    
    Vector2 nextPos = Vector2.one;

    private void Start()
    {
        transform.position = Vector3.zero;
        playerTransform = transform.position;
        isMoveing = true;
    }

    private void Update()
    {
        MoveDirection();
    }

    private void MoveDirection()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !isMoveing)
        {
            moveDirection = new Vector2(0, 1);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !isMoveing)
        {
            moveDirection = new Vector2(0, -1);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !isMoveing)
        {
            moveDirection = new Vector2(-1, 0);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !isMoveing)
        {
            moveDirection = new Vector2(1, 0);
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        Move(moveDirection);
    }

    private void Move(Vector2 moveDirection)
    {
        isMoveing = true;
        var controlResult = DistanceControl(moveDirection);

        Vector2 move = controlResult.Item1;
        float dis = controlResult.Item2;

        nextPos.x = playerTransform.x + (dis * move.x);
        nextPos.y = playerTransform.y + (dis * move.y);

        transform.position = Vector3.MoveTowards(transform.position, nextPos, lerpTime * Time.deltaTime);
       
        Vector2 posControl = transform.position;
        if (posControl == nextPos)
        {
            isMoveing = false;
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
                Vector2 targetPos = hit.collider.gameObject.transform.position;
                distance = Vector2.Distance(playerTransform, targetPos) - 1;
                return (moveDirection, distance);
            }
        }
        return (moveDirection, 0);
    }
}
