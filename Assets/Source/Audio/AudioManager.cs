using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup musicAudioMixer;
    [SerializeField] private AudioMixerGroup soundAudioMixer;
    private string MusicVolumeKey = "Music";
    private string SoundVolumeKey = "Sounds";

    private void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey);
        Debug.Log(musicVolume);
        float soundVolume = PlayerPrefs.GetFloat(SoundVolumeKey);
        SetMusicVolume(musicAudioMixer, musicVolume, MusicVolumeKey);
    }

    private void SetMusicVolume(AudioMixerGroup mixer, float volume, string keyForPlayerPrefs)
    {
        mixer.audioMixer.SetFloat(keyForPlayerPrefs, volume * 100);
        PlayerPrefs.SetFloat(keyForPlayerPrefs, volume);
    }

    public void ChangeMusicVolumeValue(TMPro.TMP_Text text)
    {
        float volume = PlayerPrefs.GetFloat(MusicVolumeKey);
        float volumeInProcent = volume;
        if (volume <= 0.0f)
        {
            volume -= 0.2f;
            volumeInProcent = volume * 100 + 100;
            if (volume == -0.8f)
            {
                volume = -0.8f;
                volumeInProcent = 0f;
            }
            else if (volume <= -0.8f)
            {
                volume = 0.0f;
                volumeInProcent = 100f;
            }
        }

        musicAudioMixer.audioMixer.SetFloat(MusicVolumeKey, volume * 100);
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);

        text.text = volumeInProcent + "%";
    }

    public void ChangeSoundVolumeValue(TMPro.TMP_Text text)
    {
        float volume = PlayerPrefs.GetFloat(SoundVolumeKey);
        float volumeInProcent = volume;
        if (volume <= 0.0f)
        {
            volume -= 0.2f;
            volumeInProcent = volume * 100 + 100;
            if (volume == -0.8f)
            {
                volume = -0.8f;
                volumeInProcent = 0f;
            }
            else if (volume <= -0.8f)
            {
                volume = 0.0f;
                volumeInProcent = 100f;
            }
        }

        soundAudioMixer.audioMixer.SetFloat(SoundVolumeKey, volume * 100);
        PlayerPrefs.SetFloat(SoundVolumeKey, volume);

        text.text = volumeInProcent + "%";
    }

    public void SetCurentVolumeValueText(TMPro.TMP_Text musicText, TMPro.TMP_Text soundText)
    {
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey);
        float soundVolume = PlayerPrefs.GetFloat(SoundVolumeKey);
        musicText.text = (musicVolume + 100) + "%";
        musicText.text = (soundVolume + 100) + "%";
    }
}
