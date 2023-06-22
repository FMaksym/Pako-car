using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayerPrefs = PlayerPrefsWrapper;

public class SelectMapUI : MonoBehaviour
{
    [Header("Maps list")]
    [SerializeField] private List<MapData> _map;

    [Header("Sound Manager")]
    [SerializeField] private SoundInMenuManager soundManager;

    [SerializeField] private AudioClip _buyMap;
    [SerializeField] private AudioClip _selectMap;
    [SerializeField] private AudioClip _notEnoughtMoney;

    [SerializeField] private CoinsAmount _coins;

    [SerializeField] private GameObject _buyMapButton;
    [SerializeField] private GameObject _selectMapButton;
    [SerializeField] private GameObject _selectedMapButton;

    [SerializeField] private GameObject _priceInfo;

    [SerializeField] private TMP_Text _moneyAmountText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _mapName;

    [SerializeField] private string _selectedMap;

    [SerializeField] private int _selectedMapIndex;
    [SerializeField] private int _currentMapIndex;

    [SerializeField] private ParameteresForGame _parametersForGame;

    private void Awake()
    {
        _moneyAmountText.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    private void Start()
    {
        SetStartedParametres(_currentMapIndex);
    }

    private void SetStartedParametres(int index)
    {
        _map[index].IsBuy = true;
        _map[index].IsSelected = true;
        PlayerPrefs.SetBool(_map[index].MapConfig.MapName, true);
        foreach (MapData map in _map)
        {
            map.gameObject.SetActive(false);
        }
        _map[index].gameObject.SetActive(true);

        _mapName.text = _map[index].MapConfig.MapName.ToString();
        _priceInfo.SetActive(false);

        if (_map[index].IsSelected)
        {
            _selectMapButton.SetActive(false);
            _selectedMapButton.SetActive(true);
        }
        else
        {
            _selectMapButton.SetActive(true);
            _selectedMapButton.SetActive(false);
        }
        _buyMapButton.SetActive(false);

        _selectedMap = _map[index].MapConfig.MapName;
        _selectedMapIndex = _map[index].MapConfig.MapIndex;

        Debug.Log("Map: " + _selectedMap + " " + _selectedMapIndex);

        _parametersForGame.GettingMap(_selectedMap, _selectedMapIndex);
    }

    public void ChangeNext()
    {
        _map[_currentMapIndex].gameObject.SetActive(false);
        _currentMapIndex++;
        if (_currentMapIndex == _map.Count)
        {
            _currentMapIndex = 0;
        }

        _map[_currentMapIndex].gameObject.SetActive(true);

        _mapName.text = _map[_currentMapIndex].MapConfig.MapName.ToString();

        bool purchased = PlayerPrefs.GetBool($"{_map[_currentMapIndex].MapConfig.MapName}");

        if (purchased)
        {
            _priceInfo.SetActive(false);
            _buyMapButton.SetActive(false);
            if (_map[_currentMapIndex].IsSelected)
            {
                _selectMapButton.SetActive(false);
                _selectedMapButton.SetActive(true);
            }
            else
            {
                _selectedMapButton.SetActive(false);
                _selectMapButton.SetActive(true);
            }
        }
        else
        {
            _priceInfo.SetActive(true);
            _priceText.text = _map[_currentMapIndex].MapConfig.Price.ToString();
            _buyMapButton.SetActive(true);
            _selectMapButton.SetActive(false);
            _selectedMapButton.SetActive(false);
        }
    }

    public void ChangePrevious()
    {
        _map[_currentMapIndex].gameObject.SetActive(false);
        _currentMapIndex--;
        if (_currentMapIndex == -1)
        {
            _currentMapIndex = _map.Count - 1;
        }

        _map[_currentMapIndex].gameObject.SetActive(true);

        _mapName.text = _map[_currentMapIndex].MapConfig.MapName.ToString();

        bool purchased = PlayerPrefs.GetBool($"{_map[_currentMapIndex].MapConfig.MapName}");

        if (purchased)
        {
            _priceInfo.SetActive(false);
            _buyMapButton.SetActive(false);
            if (_map[_currentMapIndex].IsSelected)
            {
                _selectMapButton.SetActive(false);
                _selectedMapButton.SetActive(true);
            }
            else
            {
                _selectedMapButton.SetActive(false);
                _selectMapButton.SetActive(true);
            }
        }
        else
        {
            _priceInfo.SetActive(true);
            _priceText.text = _map[_currentMapIndex].MapConfig.Price.ToString();
            _buyMapButton.SetActive(true);
            _selectMapButton.SetActive(false);
            _selectedMapButton.SetActive(false);
        }
    }

    public void OnClickSelectMap()
    {
        UnchoisenMap();

        //soundManager.EventAudioSound(_selectMap);

        _map[_currentMapIndex].IsSelected = true;

        _selectedMap = _map[_currentMapIndex].MapConfig.MapName;
        _selectedMapIndex = _map[_currentMapIndex].MapConfig.MapIndex;

        _parametersForGame.GettingMap(_selectedMap, _selectedMapIndex);

        PlayerPrefs.SetString($"SelectedMap ", _map[_currentMapIndex].MapConfig.MapName);
        _selectMapButton.SetActive(false);
        _selectedMapButton.SetActive(true);
    }

    public void OnClickBuyMap()
    {
        int carPrice = Convert.ToInt32(_priceText.text);
        if (_coins.IsEnought(carPrice))
        {
            _coins.SpendCoins(carPrice);

            _map[_currentMapIndex].IsBuy = true;
            PlayerPrefs.SetBool(_map[_currentMapIndex].MapConfig.MapName, true);

            _priceInfo.SetActive(false);
            _buyMapButton.SetActive(false);
            _selectMapButton.SetActive(true);
            _selectedMapButton.SetActive(false);

            _moneyAmountText.text = PlayerPrefs.GetInt("Coins").ToString();
            soundManager.EventAudioSound(_buyMap);
        }
        else
        {
            soundManager.EventAudioSound(_notEnoughtMoney);
        }
    }

    private void UnchoisenMap()
    {
        foreach (MapData map in _map)
        {
            if (map.IsSelected)
            {
                map.IsSelected = false;
            }
        }
    }
}
