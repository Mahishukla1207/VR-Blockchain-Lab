using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip introClip;
    public AudioClip failureClip;

    public void PlayIntro()
    {
        audioSource.Stop();
        audioSource.clip = introClip;
        audioSource.Play();
    }

    public void PlayFailure()
    {
        audioSource.Stop();
        audioSource.clip = failureClip;
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}