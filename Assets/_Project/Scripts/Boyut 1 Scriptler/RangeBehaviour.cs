using System;
using System.Collections.Generic;
using UnityEngine;

public class RangeBehaviour : MonoBehaviour
{
    [SerializeField] private BirDCharacterController _birDCharacterController;
    
    public Enemy1 enemies;

    public bool tutorial = true;

    private void Start()
    {
        tutorial = true;
    }

    public void DestroyRangeEnemies()
    {
        if (enemies == null) return;
        enemies.TakeDamage();
        TimeScaleManager.instance.ResetTimeScale();
        _birDCharacterController.lockMovement = false;
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out Enemy1 enemy))
        {
            enemies = enemy;

            if (tutorial)
            {
                _birDCharacterController.lockMovement = true;
                TimeScaleManager.instance.SetTimeScale(0.0f);
                tutorial = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out Enemy1 enemy))
        {
            if (enemy == enemies)
                enemies = null;
        }
    }
}
