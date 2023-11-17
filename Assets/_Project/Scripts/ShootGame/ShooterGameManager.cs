using System;
using UnityEngine;

public class ShooterGameManager : MonoBehaviour
{
    public UcgenEnemySpawner ucgenEnemySpawner;
    public BirDCharacterController birDCharacterController;
    public GameObject Canvas;


    private void Start()
    {
        Canvas.SetActive(true);
    }

    public void OyunuBaslat()
    {
        birDCharacterController.lockMovement = false;
        ucgenEnemySpawner.StartSpawning();
        Canvas.SetActive(false);
    }
}
