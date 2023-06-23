using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using PlayerPrefs = PlayerPrefsWrapper;

public class SelectCarUI : MonoBehaviour, ICanvas
{
    [Header("Sound Manager")]
    [SerializeField] private SoundInMenuManager soundManager;

    [SerializeField] private AudioClip _buyCar;
    [SerializeField] private AudioClip _selectCar;
    [SerializeField] private AudioClip _notEnoughtMoney;

    [Header("Amount Money Text")]
    [SerializeField] TMP_Text _moneyAmountText;

    [Header("Price Text")]
    [SerializeField] TMP_Text _priceText;

    [Header("List with Cars")]
    public List<CarGarageData> _car;

    [Header("Buttons For Select Car")]
    [SerializeField] private GameObject _nextCarButton;
    [SerializeField] private GameObject _previousCarButton;
    [SerializeField] private GameObject _buyCarButton;
    [SerializeField] private GameObject _selectCarButton;
    [SerializeField] private GameObject _equipedCarButton;

    [Header("Car info border")]
    [SerializeField] private GameObject _carInfoForBuy;
    [SerializeField] private GameObject _carInfo;

    [Header("Panels")]
    [SerializeField] private GameObject _selectCarPanel;
    [SerializeField] private GameObject _selectColorOfCarPanel;

    [Header("Car Parametres Text")]
    [SerializeField] private TMP_Text _nameOfCarInBuyBorder;
    [SerializeField] private TMP_Text _nameOfCarInInfoBorder;

    [Header("Canvases")]
    [SerializeField] private GameObject _GarageCanvas;

    [SerializeField] private GameObject _selectedCar;

    public int _currentCarIndex;

    [Space(5), Header("Autofiller")]
    [SerializeField] private AutofillerOfParametres _autofiller;

    private SelectColorOfCarUI selectColorOfCarUIManager;
    [SerializeField] private CoinsAmount _coins;

    private void Awake()
    {
        _moneyAmountText.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    private void Start()
    {
        selectColorOfCarUIManager = _autofiller.selectColorOfCarUIManager;
        PlayerPrefs.SetInt("SelectedCar", 0);
        _currentCarIndex = PlayerPrefs.GetInt("SelectedCar");
        SetStartedParametres(_currentCarIndex);
    }

    private void SetStartedParametres(int index)
    {
        _car[index].IsBuy = true;
        _car[index].IsSelected = true;
        PlayerPrefs.SetBool(_car[index].CarConfig.Name, true);
        foreach (CarGarageData car in _car)
        {
            car.gameObject.SetActive(false);
        }
        _car[index].gameObject.SetActive(true);

        _carInfoForBuy.SetActive(false);
        _carInfo.SetActive(true);

        _nameOfCarInInfoBorder.text = _car[index].CarConfig.Name.ToString();

        if (_car[index].IsSelected)
        {
            _selectCarButton.SetActive(false);
            _equipedCarButton.SetActive(true);
        }
        else
        {
            _selectCarButton.SetActive(true);
            _equipedCarButton.SetActive(false);
        }
        _buyCarButton.SetActive(false);
    }

    public void ChangeNext()
    {
        soundManager.EventAudioSound(_selectCar);
        _car[_currentCarIndex].gameObject.SetActive(false);
        _currentCarIndex++;
        if (_currentCarIndex == _car.Count)
        {
            _currentCarIndex = 0;
        }

        _car[_currentCarIndex].gameObject.SetActive(true);

        _nameOfCarInBuyBorder.text = _car[_currentCarIndex].CarConfig.Name.ToString();

        bool purchased = PlayerPrefs.GetBool($"{_car[_currentCarIndex].CarConfig.Name}");

        if (purchased)
        {
            _carInfoForBuy.SetActive(false);
            _carInfo.SetActive(true);
            _nameOfCarInInfoBorder.text = _car[_currentCarIndex].CarConfig.Name.ToString();
            _buyCarButton.SetActive(false);
            if (_car[_currentCarIndex].IsSelected)
            {
                _selectCarButton.SetActive(false);
                _equipedCarButton.SetActive(true);
            }
            else
            {
                _equipedCarButton.SetActive(false);
                _selectCarButton.SetActive(true);
            }
        }
        else
        {
            _carInfoForBuy.SetActive(true);
            _carInfo.SetActive(false);
            _priceText.text = _car[_currentCarIndex].CarConfig.Price.ToString();
            _nameOfCarInInfoBorder.text = _car[_currentCarIndex].CarConfig.Name.ToString();
            _buyCarButton.SetActive(true);
            _selectCarButton.SetActive(false);
            _equipedCarButton.SetActive(false);
        }
    }

    public void ChangePrevious()
    {
        soundManager.EventAudioSound(_selectCar);
        _car[_currentCarIndex].gameObject.SetActive(false);
        _currentCarIndex--;
        if (_currentCarIndex == -1)
        {
            _currentCarIndex = _car.Count - 1;
        }

        _car[_currentCarIndex].gameObject.SetActive(true);

        _nameOfCarInBuyBorder.text = _car[_currentCarIndex].CarConfig.Name.ToString();

        bool purchased = PlayerPrefs.GetBool($"{_car[_currentCarIndex].CarConfig.Name}");

        if (purchased)
        {
            _carInfoForBuy.SetActive(false);
            _carInfo.SetActive(true);
            _nameOfCarInInfoBorder.text = _car[_currentCarIndex].CarConfig.Name.ToString();
            _buyCarButton.SetActive(false);
            if (_car[_currentCarIndex].IsSelected)
            {
                _selectCarButton.SetActive(false);
                _equipedCarButton.SetActive(true);
            }
            else
            {
                _equipedCarButton.SetActive(false);
                _selectCarButton.SetActive(true);
            }
        }
        else
        {
            _carInfoForBuy.SetActive(true);
            _carInfo.SetActive(false);
            _priceText.text = _car[_currentCarIndex].CarConfig.Price.ToString();
            _nameOfCarInInfoBorder.text = _car[_currentCarIndex].CarConfig.Name.ToString();
            _buyCarButton.SetActive(true);
            _selectCarButton.SetActive(false);
            _equipedCarButton.SetActive(false);
        }
    }

    public void OnClickSelectCar()
    {
        bool purchased;
        UnchoisenCar();

        purchased = PlayerPrefs.GetBool($"{_car[_currentCarIndex].CarConfig.Name}");

        if (purchased)
        {
            _car[_currentCarIndex].IsSelected = true;
        }

        PlayerPrefs.SetInt("SelectedCar", _currentCarIndex);
        _selectCarButton.SetActive(false);
        _equipedCarButton.SetActive(true);
        soundManager.EventAudioSound(_selectCar);
    }

    public void OnClickBuyCar()
    {
        int carPrice = Convert.ToInt32(_priceText.text);
        if (_coins.IsEnought(carPrice))
        {
            soundManager.EventAudioSound(_buyCar);
            _coins.SpendCoins(carPrice);
            
            _car[_currentCarIndex].IsBuy = true;
            PlayerPrefs.SetBool(_car[_currentCarIndex].CarConfig.Name, true);
            
            _buyCarButton.SetActive(false);
            _selectCarButton.SetActive(true);
            _equipedCarButton.SetActive(false);

            _moneyAmountText.text = PlayerPrefs.GetInt("Coins").ToString();
        }
        else
        {
            soundManager.EventAudioSound(_notEnoughtMoney);
        }
    }

    private void UnchoisenCar()
    {
        foreach (CarGarageData car in _car)
        {
            if (car.IsSelected)
            {
                car.IsSelected = false;
            }
        }
    }
}