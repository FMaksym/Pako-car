using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayerPrefs = PlayerPrefsWrapper;
using System;
using Zenject;

public class SelectColorOfCarUI : MonoBehaviour, ICanvas
{
    [SerializeField] private List<ListOfCarsColor> _listOfCarsColor;

    [SerializeField] private GameObject _selectedCar;

    [SerializeField] private GameObject _buyCarColorButton;
    [SerializeField] private GameObject _selectCarColorButton;
    [SerializeField] private GameObject _selectedCarColorButton;

    [Header("Amount Money Text")]
    [SerializeField] TMP_Text _moneyAmountText;

    [Header("Price Text")]
    [SerializeField] TMP_Text _priceText;

    [Header("Panels")]
    [SerializeField] private GameObject _selectColorOfCarPanel;
    [SerializeField] private GameObject _selectCarPanel;

    [Header("Car Color info borders")]
    [SerializeField] private GameObject _carColorInfoForBuy;
    [SerializeField] private GameObject _carColorInfo;

    [SerializeField] private TMP_Text _ColorOfCarInBuyBorder;
    [SerializeField] private TMP_Text _ColorOfCarInInfoBorder;

    [SerializeField] private int _currentColorIndex;

    [Space(5), Header("Autofiller")]
    [SerializeField] private AutofillerOfParametres _autofiller;

    private SelectCarUI _selectCarUIManager;

    [SerializeField] private ParameteresForGame _parametersForGame;

    [SerializeField] private CoinsAmount _coins;

    private void Start()
    {
        _selectCarUIManager = _autofiller.selectCarUIManager;
        _currentColorIndex = 0;
        PlayerPrefs.SetInt ( SetSelectedColorNameForPlayerPrefs(_listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].Color) , 0);
        Debug.Log( SetSelectedColorNameForPlayerPrefs(_listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].Color));
        _currentColorIndex = PlayerPrefs.GetInt( SetSelectedColorNameForPlayerPrefs(_listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].Color));
        Debug.Log(_currentColorIndex);

        SetStartedParametres(_currentColorIndex);
    }

    private void SetStartedParametres(int index)
    {
        _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[index].IsBuy = true;
        _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[index].IsSelected = true;
        PlayerPrefs.SetBool(_listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[index].Name, true);
        _selectedCar = _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[index]._modelForSelect;
        foreach (ListOfCarsColor car in _listOfCarsColor)
        {
            int Index = 0;
            _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[Index].gameObject.SetActive(false);
            Index++;
        }
        Debug.Log("All cars false");
        _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[index].gameObject.SetActive(true);
        Debug.Log("Car " + _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[index].Color + " true");

        ClosingOpeningInfoPanelsIfBuyingOrPurchased();

        _ColorOfCarInInfoBorder.text = _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[index].Color.ToString();

        if (_listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[index].IsSelected)
        {
            _selectCarColorButton.SetActive(false);
            _selectedCarColorButton.SetActive(true);
        }
        else
        {
            _selectCarColorButton.SetActive(true);
            _selectedCarColorButton.SetActive(false);
        }
        _buyCarColorButton.SetActive(false);

        Debug.Log(" " + _selectedCar.gameObject.name);
        _parametersForGame.GettingCar(_selectedCar);
    }

    private string SetSelectedColorNameForPlayerPrefs(string name)
    {
        string nameSelectedColor = "SelectedColor_" + name;
        return nameSelectedColor;
    }

    public void ChangeNext()
    {
        _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].gameObject.SetActive(false);
        _currentColorIndex++;
        if (_currentColorIndex == _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList.Count)
        {
            _currentColorIndex = 0;
        }

        _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].gameObject.SetActive(true);

        bool purchased = PlayerPrefs.GetBool($"{_listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].Name}");

        CheckingPurchaseMachine(purchased);
        //if (purchased)
        //{
        //    ClosingOpeningInfoPanelsIfBuyingOrPurchased();
        //    _ColorOfCarInInfoBorder.text = _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].Color.ToString();
        //    _buyCarColorButton.SetActive(false);
        //    if (_listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].IsSelected)
        //    {
        //        _selectCarColorButton.SetActive(false);
        //        _selectedCarColorButton.SetActive(true);
        //    }
        //    else
        //    {
        //        _selectedCarColorButton.SetActive(false);
        //        _selectCarColorButton.SetActive(true);
        //    }
        //}
        //else
        //{
        //    _carColorInfoForBuy.SetActive(true);
        //    _carColorInfo.SetActive(false);
        //    _priceText.text = _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].Price.ToString();
        //    _ColorOfCarInBuyBorder.text = _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].Color.ToString();
        //    HideButtonsIfNotPurchased();
        //}

        //PlayerPrefs.SetInt("SelectedCar", _currentIndex);
    }

    public void ChangePrevious()
    {
        _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].gameObject.SetActive(false);
        _currentColorIndex--;
        if (_currentColorIndex == -1)
        {
            _currentColorIndex = _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList.Count - 1;
        }

        _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].gameObject.SetActive(true);

        bool purchased = PlayerPrefs.GetBool($"{_listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].Name}");

        CheckingPurchaseMachine(purchased);
    }

    public void OnClickSelectColor()
    {
        UnchoisenCarColor(_currentColorIndex);

        //AudioSource.PlayClipAtPoint(_equipGunSound, Camera.main.transform.position, 50f);

        _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].IsSelected = true;
        _selectedCar = _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex]._modelForSelect;

        _parametersForGame.GettingCar(_selectedCar);

        Debug.Log(" " + _selectedCar.gameObject.name);

        PlayerPrefs.SetInt($"SelectedColor {_selectCarUIManager._car[_selectCarUIManager._currentCarIndex].CarConfig.Name}", _currentColorIndex);
        _selectCarColorButton.SetActive(false);
        _selectedCarColorButton.SetActive(true);
    }

    public void OnClickBuyColor()
    {
        int carPrice = Convert.ToInt32(_priceText.text);
        if (_coins.IsEnought(carPrice))
        {
            _coins.SpendCoins(carPrice);

            ClosingOpeningInfoPanelsIfBuyingOrPurchased();

            _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].IsBuy = true;
            PlayerPrefs.SetBool(_listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].Name, true);

            HideButtonsWhenBuying();
            _buyCarColorButton.SetActive(false);
            _selectCarColorButton.SetActive(true);
            _selectedCarColorButton.SetActive(false);

            _moneyAmountText.text = PlayerPrefs.GetInt("Coins").ToString();
            //AudioSource.PlayClipAtPoint(_buyGunSound, Camera.main.transform.position, 50f);
        }
        else
        {
            ClosingOpeningPanelsIfNotPurchased();
            //AudioSource.PlayClipAtPoint(_notEnoughtCoinSound, Camera.main.transform.position, 50f);
        }
    }

    private void UnchoisenCarColor(int index)
    {
        foreach (ListOfCarsColor car in _listOfCarsColor)
        {
            foreach(CarDataForGame carData in car._carColorList)
            {
                if (carData.IsSelected)
                {
                    carData.IsSelected = false;
                }
            }
        }
    }

    private void CheckingPurchaseMachine(bool purchaseStatus)
    {
        if (purchaseStatus)
        {
            ClosingOpeningInfoPanelsIfBuyingOrPurchased();
            _ColorOfCarInInfoBorder.text = _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].Color.ToString();
            _buyCarColorButton.SetActive(false);
            if (_listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].IsSelected)
            {
                _selectCarColorButton.SetActive(false);
                _selectedCarColorButton.SetActive(true);
            }
            else
            {
                _selectedCarColorButton.SetActive(false);
                _selectCarColorButton.SetActive(true);
            }
        }
        else
        {
            ClosingOpeningPanelsIfNotPurchased();
            _priceText.text = _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].Price.ToString();
            _ColorOfCarInBuyBorder.text = _listOfCarsColor[_selectCarUIManager._currentCarIndex]._carColorList[_currentColorIndex].Color.ToString();
            HideButtonsIfNotPurchased();
        }
    }

    public void ClosingOpeningInfoPanelsIfBuyingOrPurchased()
    {
        _carColorInfoForBuy.SetActive(false);
        _carColorInfo.SetActive(true);
    }

    public void ClosingOpeningPanelsIfNotPurchased()
    {
        _carColorInfoForBuy.SetActive(true);
        _carColorInfo.SetActive(false);
    }

    public void HideButtonsIfNotPurchased()
    {
        _buyCarColorButton.SetActive(true);
        _selectCarColorButton.SetActive(false);
        _selectedCarColorButton.SetActive(false);
    }

    public void HideButtonsWhenBuying()
    {
        _buyCarColorButton.SetActive(false);
        _selectCarColorButton.SetActive(true);
        _selectedCarColorButton.SetActive(false);
    }

    public void OnClickBackToSelectCar()
    {
        _currentColorIndex = 0;
        //_currentColorIndex++;
        foreach (ListOfCarsColor car in _listOfCarsColor)
        {
            car.gameObject.SetActive(false);
            car._carColorList[_currentColorIndex].gameObject.SetActive(false);
        }

        //PlayerPrefs.SetInt("SelectedCar", 0);
    }
}
