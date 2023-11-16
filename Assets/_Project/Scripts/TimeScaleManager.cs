using System.Collections;
using UnityEngine;

public class TimeScaleManager : MonoBehaviour
{
    public static TimeScaleManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if(instance != this) Destroy(this.gameObject);
    }


    public void SetTimeScale(float timeScale)
    {
        StartCoroutine(SmoothTimeScale(timeScale));
    }

    
    private static IEnumerator SmoothTimeScale(float timeScale)
    {
        while (Time.timeScale > timeScale)
        {
            if (Time.timeScale - Time.deltaTime * 2 < 0.001f)
            {
                Time.timeScale = 0.001f;
                break;
            }
            
            Time.timeScale -= Time.deltaTime * 2;

            yield return new WaitForFixedUpdate();
        }

        yield break;
    }

    public void ResetTimeScale()
    {
        StopAllCoroutines();
        Time.timeScale = 1;
    }
}
