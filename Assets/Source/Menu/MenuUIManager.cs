using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    //[SerializeField] private GameObject startGameButton;

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

    [SerializeField] private TMP_Text _musicVolumeValueText;
    [SerializeField] private TMP_Text _soundVolumeValueText;

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
    }

    public void GarageBackToMenu()
    {
        OpenClosedCanvas(_garageCanvas, _garageCamera, _menuCanvas, _menuCamera);
    }

    public void GarageToMaps()
    {
        OpenClosedCanvas(_garageCanvas, _garageCamera, _mapsCanvas, _mapsCamera);
    }

    public void MapsBackToGarage()
    {
        OpenClosedCanvas(_mapsCanvas, _mapsCamera, _garageCanvas, _garageCamera);
    }

    public void CarToSelectColor()
    {
        _selectCarPanel.SetActive(false);
        _selectColorPanel.SetActive(true);
    }

    public void SelectColorBackToCar()
    {
        _selectColorPanel.SetActive(false);
        _selectCarPanel.SetActive(true);
    }

    public void MenuToSettings()
    {
        OpenClosedCanvas(_menuCanvas, _menuCamera, _settingsCanvas, _settingsCamera);
    }

    public void SettingsBackToMenu()
    {
        OpenClosedCanvas(_settingsCanvas, _settingsCamera, _menuCanvas, _menuCamera);
    }

    public void ChangeMusicVolume()
    {
        _audioManager.ChangeMusicVolumeValue(_musicVolumeValueText);
    }

    public void ChangeSoundVolume()
    {
        _audioManager.ChangeSoundVolumeValue(_soundVolumeValueText);
    }
}
