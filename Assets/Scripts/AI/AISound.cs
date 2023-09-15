using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] ShootAudioClip;
    public AudioClip[] HitAudioClip;

    public void ShootSoundEffect()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        int choiceSound = Random.Range(0, ShootAudioClip.Length);
        audioSource.clip = ShootAudioClip[choiceSound];
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
}
