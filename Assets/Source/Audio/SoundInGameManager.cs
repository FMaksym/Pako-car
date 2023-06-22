using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInGameManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [Header("Buttons Audio Clips")]
    [SerializeField] private AudioClip _defaultButtonSound;
    [SerializeField] private AudioClip _changerVolumeButtonSound;

    public void DefaultButtonClickSound()
    {
        audioSource.clip = _defaultButtonSound;
        audioSource.Play();
    }

    public void ChangerVolumeButtonClickSound()
    {
        audioSource.clip = _defaultButtonSound;
        audioSource.Play();
    }

    public void EventAudioSound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
