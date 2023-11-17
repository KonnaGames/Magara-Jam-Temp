using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GuitarHeroManager;

public enum Direction
{
    Up, Down, Left, Right
}

public class Box : MonoBehaviour,IDestroyable
{
    private event Action<Box> _onBoxDestroyedEvent;
    private event Action<Box> _onBoxHidden;

    [SerializeField] private GameObject _directionArrow;
    [SerializeField] private Direction _direction;

    private SpawnPlace _spawnPlace;
    private Vector3 _moveDirection;
    private bool _canMove = false;
    private float _speed;
    private bool _isDestroyed = false;

    public bool IsDestroyed => _isDestroyed;

    public Direction Direction => _direction;

    public SpawnPlace SpawnPlace => _spawnPlace;

    public void Initialize(float speed,SpawnPlace spawnPlace, Vector3 moveDirection,Action<Box> pushBox)
    {
        SubscribeDestroyedPushEvent(pushBox);
        SubscribeHiddenPushEvent(pushBox);

        _spawnPlace = spawnPlace;
        _direction = spawnPlace.Direction;
        _speed = speed;
        _moveDirection = moveDirection;
        transform.position = spawnPlace.Position.position;
        _isDestroyed = false;

        _directionArrow.GetComponent<SpriteRenderer>().color = spawnPlace.Color;

        SetArrowDirection(_direction);
    }

    public void SubscribeDestroyedPushEvent(Action<Box> pushBox)
    {
        _onBoxDestroyedEvent -= pushBox;
        _onBoxDestroyedEvent += pushBox;
    }

    public void SubscribeHiddenPushEvent(Action<Box> pushBox)
    {
        _onBoxHidden -= pushBox;
        _onBoxHidden += pushBox;
    }

    private void SetArrowDirection(Direction direction)
    {
        _directionArrow.transform.eulerAngles = Vector3.zero;
        switch (direction)
        {
            case Direction.Up:
                _directionArrow.transform.Rotate(Vector3.zero);
                break;
            case Direction.Right:
                _directionArrow.transform.Rotate(Vector3.forward * 270);
                break;
            case Direction.Down:
                _directionArrow.transform.Rotate(Vector3.forward * 180);
                break;
            case Direction.Left:
                _directionArrow.transform.Rotate(Vector3.forward * 90);
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if(_canMove)
        {
            transform.Translate(_moveDirection * _speed * Time.deltaTime);
        }
    }

    public void StartMove()
    {
        _canMove = true;
    }

    public void StopMoving()
    {
        _canMove = false;
    }

    public void Hide()
    {
        _isDestroyed = true;
        _onBoxHidden?.Invoke(this);
    }

    public void Destroy()
    {
        _isDestroyed = true;
        _onBoxDestroyedEvent?.Invoke(this);
    }


    [Serializable]
    public struct ParticleSettings
    {
        public GameObject ArrowDestroyParticle;
    }

}
