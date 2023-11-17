using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarHeroController : MonoBehaviour
{
    [SerializeField] private CheckArea _checkArea;
    [SerializeField] private ParticleInstaller _particleInstaller;
    [SerializeField] private CameraShake _cameraShake;
    [SerializeField] private CameraShakeSettings _cameraShakeSettings;
    [SerializeField] private CreateParticleSettings _createParticleSettings;

    private bool _isBoxInArea = false;
    private Box _boxInArea;

    private int _successCount = 0;
    private int _failCount = 0;

    private void Start()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        _checkArea.SubscribeEvents(OnBoxEntered,OnBoxExited);
    }

    private void Update()
    {
        if (!_isBoxInArea)
            return;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            OnKeyDown(Direction.Down);
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            OnKeyDown(Direction.Up);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            OnKeyDown(Direction.Right);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            OnKeyDown(Direction.Left);
    }

    private void OnBoxEntered(Box obj)
    {
        _isBoxInArea = true;
        _boxInArea = obj;
    }

    private void OnBoxExited(Box obj)
    {
        if (!obj.IsDestroyed)
            OnMissedKey();

        _isBoxInArea = false;
        _boxInArea = null;
    }

    private void OnKeyDown(Direction direction)
    {
        if (direction == _boxInArea.Direction)
            OnRightKeyDown();
        else
            OnWrongKeyDown();
    }

    private void OnRightKeyDown()
    {
        _successCount++;

        Vector3 targetPos = _checkArea.transform.position;
        targetPos.y = _boxInArea.transform.position.y;
        _boxInArea.transform.position = targetPos;

        _boxInArea.StopMoving();
        StartCoroutine(CreateParticle(_boxInArea, _createParticleSettings.ParticleDelay));
        print("Success: " + _successCount);
    }

    private void OnWrongKeyDown()
    {
        _failCount++;
        print("Fail: " + _failCount);
        _cameraShake.StartCameraShake(_cameraShakeSettings.Duration, _cameraShakeSettings.Magnitude);
    }

    private void OnMissedKey()
    {
        _failCount++;
        print("Fail: " + _failCount);
        _boxInArea.SubscribeDestroyedPushEvent(OnBoxDestroyed);
    }

    //When reached Destroyable
    private void OnBoxDestroyed(Box box)
    {
        _cameraShake.StartCameraShake(_cameraShakeSettings.Duration, _cameraShakeSettings.Magnitude);
    }

    private IEnumerator CreateParticle(Box box,float delay)
    {
        yield return new WaitForSeconds(delay);
        box.Hide();
        GameObject particle = Instantiate(_particleInstaller.GuitarHeroParticles.BoxParticleSettings.ArrowDestroyParticle);
        particle.transform.position = box.transform.position;
        particle.GetComponent<SpriteRenderer>().color = box.SpawnPlace.Color;

        Destroy(particle, 1);
    }

    [Serializable]
    public struct CameraShakeSettings
    {
        public float Duration;
        public float Magnitude;
    }

    [Serializable]
    public struct CreateParticleSettings
    {
        public float ParticleDelay;
    }
}
