using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 _originalPosition;
    private void Start()
    {
        _originalPosition = transform.position;
    }

    public void StartCameraShake(float duration, float magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }
    private IEnumerator Shake(float duration, float magnitude)
    {
        var elapsed = 0f;

        while (elapsed < duration)
        {
            var x = Random.Range(-1f, 1f) * magnitude;
            var y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, -10f);
            elapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = _originalPosition;
    }
}
