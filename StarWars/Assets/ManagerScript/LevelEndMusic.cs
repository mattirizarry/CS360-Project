using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Removed the PlayMusic call from Start and loop setting
    }
    public void Play()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play(); // Plays the assigned AudioClip
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is missing!");
        }
    }
}
