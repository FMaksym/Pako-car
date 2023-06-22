using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] musicTracks;
    private const string SelectedTrackIndexKey = "SelectedTrackIndex";

    private int selectedTrackIndex;

    private void Start()
    {
        selectedTrackIndex = PlayerPrefs.GetInt(SelectedTrackIndexKey);
        PlaySelectedTrack();
    }

    public void NextTrack(TMPro.TMP_Text text)
    {
        selectedTrackIndex = (selectedTrackIndex + 1) % musicTracks.Length;
        if (selectedTrackIndex == musicTracks.Length)
        {
            selectedTrackIndex = 0;
        }
        PlaySelectedTrack();
        text.text = "#" + (selectedTrackIndex + 1).ToString();
    }

    public void PreviousTrack()
    {
        selectedTrackIndex = (selectedTrackIndex - 1 + musicTracks.Length) % musicTracks.Length;
        PlaySelectedTrack();
    }

    private void PlaySelectedTrack()
    {
        AudioClip selectedTrack = musicTracks[selectedTrackIndex];

        audioSource.clip = selectedTrack;
        audioSource.Play();

        PlayerPrefs.SetInt(SelectedTrackIndexKey, selectedTrackIndex);
    }

    public void StopTrack()
    {
        audioSource.Pause();
    }

    public void PlayTrack()
    {
        audioSource.Play();
    }
}
