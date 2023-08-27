using System;
using UnityEngine;

public class EarningCoins : MonoBehaviour
{
    [SerializeField] private TimerController _timerController;
    [SerializeField] private CoinsAmount _coins;
    [SerializeField] private int _valueMultiplierMoneyPerTime = 20;
    [SerializeField] private int _defaultAmountOfMoneyPerStage = 500;

    public int _allCoinsForGame;
    private int _coinsFromTime;
    private int _coinsPerStage;

    public int AddCoinsFromTime(float gameTime)
    {
        int time = Convert.ToInt32(gameTime);
        _coinsFromTime = time * _valueMultiplierMoneyPerTime;
        _allCoinsForGame += _coinsFromTime;
        _coins.AddCoins(_allCoinsForGame);
        return _coinsFromTime;
    }

    public int AddCoinsPerStage(int stageValue)
    {
        _coinsPerStage = stageValue * _defaultAmountOfMoneyPerStage;
        _allCoinsForGame += _coinsPerStage;
        Debug.Log("+" + _coinsPerStage);
        return _coinsPerStage;
    }
}
