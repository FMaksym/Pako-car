using UnityEngine;
using Zenject;
using Cinemachine;

public class PlayerCinemachieCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cameraTopDown;
    [SerializeField] private CinemachineVirtualCamera _camera3face;

    [Inject] private readonly CarController _carPosition;

    private void Start()
    {
        _cameraTopDown.Follow = _carPosition.transform;
        _camera3face.Follow = _carPosition.transform;
        _camera3face.LookAt = _carPosition.transform;
    }

    public void ChangeCamera(TMPro.TMP_Text ChangeCameraButtonText)
    {
        if (_cameraTopDown.gameObject.activeSelf)
        {
            ChangeCameraButtonText.text = "#2";
            _cameraTopDown.gameObject.SetActive(false);
            _camera3face.gameObject.SetActive(true);
        }
        else if(_camera3face.gameObject.activeSelf)
        {
            ChangeCameraButtonText.text = "#1";
            _camera3face.gameObject.SetActive(false);
            _cameraTopDown.gameObject.SetActive(true);
        }
    }
}
