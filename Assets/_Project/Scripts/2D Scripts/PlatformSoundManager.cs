using UnityEngine;

public class PlatformSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip downSound;

    int a = 1;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }
}
