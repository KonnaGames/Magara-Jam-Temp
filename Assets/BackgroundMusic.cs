using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;
    private AudioSource _audioSource;
    private void Start()
    {
        instance = this;
        _audioSource = GetComponent<AudioSource>();
    }


    public void MusicDegistir(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();

    }
}
