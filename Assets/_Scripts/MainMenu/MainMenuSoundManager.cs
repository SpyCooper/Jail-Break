using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource effectsSource;
    [SerializeField] private AudioSource backgroundSource;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip mainSirenSFX;
    [SerializeField] private AudioClip distantSirenSFX1;
    [SerializeField] private AudioClip distantSirenSFX2;

    private float gameVolume;
    private float musicVolume;

    private float sirenTimerMax = 10f;
    private float sirenTimer = 0f;
    private bool allowDistantSirens = false;

    private void Start()
    {
        backgroundSource.clip = backgroundMusic;
        StartCoroutine(MainSiren());

        SetGameVolume();
        SetMusicVolume();
    }

    private void Update()
    {
        if(allowDistantSirens)
        {
            sirenTimer += Time.deltaTime * Random.Range(0, 10);
            if(sirenTimer > sirenTimerMax)
            {
                sirenTimer = 0f;
                StartCoroutine(SirenSound());
            }
        }
    }

    private void SetGameVolume()
    {
        gameVolume = GameManager.Instance.GetGameSoundVolume();
    }

    private void SetMusicVolume()
    {
        musicVolume = GameManager.Instance.GetMusicSoundVolume()/10f;
    }

    public void PlaySoundEffect(AudioClip sfx)
    {
        effectsSource.PlayOneShot(sfx, gameVolume);
    }

    public void PlayMusic()
    {
        effectsSource.PlayOneShot(backgroundMusic, musicVolume);
    }

    private IEnumerator MainSiren()
    {
        yield return new WaitForSeconds(1f);
        PlaySoundEffect(mainSirenSFX);
        yield return new WaitForSeconds(3f);
        backgroundSource.Play();
        allowDistantSirens = true;
    }
    

    private IEnumerator SirenSound()
    {
        allowDistantSirens = false;
        float temp = Random.Range(0, 2);
        if(temp % 2 == 0)
        {
            PlaySoundEffect(distantSirenSFX1);
        }
        else
        {
            PlaySoundEffect(distantSirenSFX2);
        }
        yield return new WaitForSeconds(10f);
        allowDistantSirens = true;
    }
}
