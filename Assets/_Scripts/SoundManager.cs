using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource effectsSource;
    [SerializeField] private AudioSource backgroundSource;
    [SerializeField] private AudioClip backgroundMusic, sfx1, sfx2;

    private float gameVolume = 0.5f;
    private float musicVolume = 0.5f;

    private void Start()
    {
        backgroundSource.clip = backgroundMusic;
        backgroundSource.Play();
    }

    public void PlaySoundEffect(AudioClip sfx)
    {
        effectsSource.PlayOneShot(sfx, gameVolume);
    }

    public void PlayMusic()
    {
        effectsSource.PlayOneShot(backgroundMusic, musicVolume);
    }
}
