using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource walkAudioSource;
    public AudioClip[] PunchAudioClip;
    public AudioClip[] HitAudioClip;
    public AudioClip[] WalkAudioClip;
    private float _timer;

    private void Start()
    {
        _timer = 0.3f;
    }

    public void PunchSoundEffect()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        int choiceSound = Random.Range(0, PunchAudioClip.Length);
        audioSource.clip = PunchAudioClip[choiceSound];
        audioSource.Play();
    }

    public void HitSoundEffect()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        int choiceSound = Random.Range(0, HitAudioClip.Length);
        audioSource.clip = HitAudioClip[choiceSound];
        audioSource.Play();
    }

    public void WalkSoundEffect(bool activ)
    {
        if (_timer <= 0)
        {
            _timer = 0.3f;
        }
        else
        {
            _timer -= Time.deltaTime;
        }

        if (!activ)
        {
            walkAudioSource.Stop();
        }
        else
        {
            int choiceSound = Random.Range(0, WalkAudioClip.Length);
            walkAudioSource.clip = WalkAudioClip[choiceSound];

            if (!walkAudioSource.isPlaying && _timer > 0.2f)
            {
                walkAudioSource.Play();
            }
        }
    }
}
