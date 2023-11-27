using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;  // Enable looping
        PlayMusic();
    }

    public void PlayMusic()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;  // Enable looping
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

}
