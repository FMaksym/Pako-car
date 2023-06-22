using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInMenuManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [Header("Buttons Audio Clips")]
    [SerializeField] private AudioClip _defaultButtonSound;
    [SerializeField] private AudioClip _changerVolumeButtonSound;
    [Header("Event Audio Clips")]
    [SerializeField] private AudioClip _nextCarClip;
    [SerializeField] private AudioClip _nextMapClip;
    [SerializeField] private AudioClip _buyCarClip;
    [SerializeField] private AudioClip _buyMapClip;
    [SerializeField] private AudioClip _selectCarClip;
    [SerializeField] private AudioClip _selectMapClip;
    [SerializeField] private AudioClip _buyClip;
    [SerializeField] private AudioClip _notEnoughtMoneyClip;

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
