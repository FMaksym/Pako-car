using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    [Header("Canvases")]
    [SerializeField] private GameObject playerInterfaceCanvas;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject loseCanvas;

    [SerializeField] private PlayerCinemachieCamera _playerCameras;
    [SerializeField] private TimerController _timerController;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private MusicManager _musicManager;

    [SerializeField] private TMP_Text _mapName;
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private TMP_Text _coinsForGameText;
    [SerializeField] private TMP_Text _timeTextLosePanel;
    [SerializeField] private TMP_Text _recordTimeTextLosePanel;
    [SerializeField] private TMP_Text _changeCameraButtonText;
    [SerializeField] private TMP_Text _musicVolumeValueText;
    [SerializeField] private TMP_Text _soundVolumeValueText;
    [SerializeField] private TMP_Text _songNumberText;

    private void Awake()
    {
        _mapName.text = "\n " + ParameteresForGame._nameOfMapForGame + "!";
        SetVolumeText(_musicVolumeValueText, _soundVolumeValueText);
        _songNumberText.text = "#" + (PlayerPrefs.GetInt("SelectedTrackIndex") + 1).ToString();
    }

    public void GameOver(string coinsText, int coinsForGame)
    {
        playerInterfaceCanvas.SetActive(false);
        loseCanvas.SetActive(true);

        _timeTextLosePanel.text = _timerController.TimeText.text;
        _recordTimeTextLosePanel.text = PlayerPrefs.GetString("RecordTimeStr");

        _coinsForGameText.text = "+" + coinsForGame.ToString();
        _coinsText.text = coinsText;
    }

    public void Pause()
    {
        playerInterfaceCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);
        playerInterfaceCanvas.SetActive(true);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(ParameteresForGame._indexOfMapForGame);
    }

    public void InMenu(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeCamera()
    {
        _playerCameras.ChangeCamera(_changeCameraButtonText);
    }

    public void ChangeMusicVolume()
    {
        _audioManager.ChangeMusicVolumeValue(_musicVolumeValueText);
    }

    public void ChangeSoundVolume()
    {
        _audioManager.ChangeSoundVolumeValue(_soundVolumeValueText);
    }

    public void ChangeMusic()
    {
        _musicManager.NextTrack(_songNumberText);
    }

    private void SetVolumeText(TMP_Text musicText, TMP_Text soundText)
    {
        _audioManager.SetCurentVolumeValueText(musicText, soundText);
    }
}
