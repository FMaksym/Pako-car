using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] private GameObject _menuCamera;
    [SerializeField] private GameObject _garageCamera;
    [SerializeField] private GameObject _mapsCamera;
    [SerializeField] private GameObject _settingsCamera;

    [Header("Canvases")]
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private GameObject _garageCanvas;
    [SerializeField] private GameObject _mapsCanvas;
    [SerializeField] private GameObject _settingsCanvas;

    [Header("Panels")]
    [SerializeField] private GameObject _selectCarPanel;
    [SerializeField] private GameObject _selectColorPanel;

    [SerializeField] private ParameteresForGame parametersForGame;

    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private SoundInMenuManager _soundManager;

    [SerializeField] private TMP_Text _musicVolumeValueText;
    [SerializeField] private TMP_Text _soundVolumeValueText;

    private void Start()
    {
        SetVolumeText(_musicVolumeValueText, _soundVolumeValueText);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(ParameteresForGame._indexOfMapForGame);
    }

    private void OpenClosedCanvas(GameObject closedCanvas, GameObject closedCamera, GameObject openedCanvas, GameObject openedCamera)
    {
        closedCanvas.SetActive(false);
        closedCamera.SetActive(false);
        openedCanvas.SetActive(true);
        openedCamera.SetActive(true);
    }

    public void StartGame()
    {
        OpenClosedCanvas(_menuCanvas,_menuCamera, _garageCanvas, _garageCamera);
        _soundManager.DefaultButtonClickSound();
    }

    public void GarageBackToMenu()
    {
        OpenClosedCanvas(_garageCanvas, _garageCamera, _menuCanvas, _menuCamera);
        _soundManager.DefaultButtonClickSound();
    }

    public void GarageToMaps()
    {
        OpenClosedCanvas(_garageCanvas, _garageCamera, _mapsCanvas, _mapsCamera);
        _soundManager.DefaultButtonClickSound();
    }

    public void MapsBackToGarage()
    {
        OpenClosedCanvas(_mapsCanvas, _mapsCamera, _garageCanvas, _garageCamera);
        _soundManager.DefaultButtonClickSound();
    }

    public void CarToSelectColor()
    {
        _selectCarPanel.SetActive(false);
        _selectColorPanel.SetActive(true);
        _soundManager.DefaultButtonClickSound();
    }

    public void SelectColorBackToCar()
    {
        _selectColorPanel.SetActive(false);
        _selectCarPanel.SetActive(true);
        _soundManager.DefaultButtonClickSound();
    }

    public void MenuToSettings()
    {
        OpenClosedCanvas(_menuCanvas, _menuCamera, _settingsCanvas, _settingsCamera);
        _soundManager.DefaultButtonClickSound();
    }

    public void SettingsBackToMenu()
    {
        OpenClosedCanvas(_settingsCanvas, _settingsCamera, _menuCanvas, _menuCamera);
        _soundManager.DefaultButtonClickSound();
    }

    public void ChangeMusicVolume()
    {
        _audioManager.ChangeMusicVolumeValue(_musicVolumeValueText);
        _soundManager.ChangerVolumeButtonClickSound();
    }

    public void ChangeSoundVolume()
    {
        _audioManager.ChangeSoundVolumeValue(_soundVolumeValueText);
        _soundManager.ChangerVolumeButtonClickSound();
    }

    private void SetVolumeText(TMP_Text musicText, TMP_Text soundText)
    {
        _audioManager.SetCurentVolumeValueText(musicText, soundText);
    }
}
