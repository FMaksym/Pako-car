using System;
using UnityEngine;
using PlayerPrefs = PlayerPrefsWrapper;

public class CoinsAmount : MonoBehaviour
{
    public delegate void BankHendler(int OldCoinValue, int newCoinsValue);
    public event BankHendler OnCoinValueChangedEvent;
    public event Action<int, int> OnCoinValueChangedActionEvent;

    public int coins;

    public int Coins
    {
        get => coins;
        set 
        {
            coins = PlayerPrefs.GetInt("Coins");
            
        }
    }    

    public void AddCoins( int amount)
    {
        coins = PlayerPrefs.GetInt("Coins");
        var oldCoinsValue = Coins;
        coins += amount;
        PlayerPrefs.SetInt("Coins", coins);
        OnCoinValueChangedEvent?.Invoke(oldCoinsValue, Coins);
        OnCoinValueChangedActionEvent?.Invoke(oldCoinsValue, Coins);
    }

    public void SpendCoins( int amount)
    {
        var oldCoinsValue = Coins;
        coins -= amount;
        PlayerPrefs.SetInt("Coins", coins);
                                                                                                                                  
        OnCoinValueChangedEvent?.Invoke(oldCoinsValue, Coins);
        OnCoinValueChangedActionEvent?.Invoke(oldCoinsValue, Coins);
    }

    public bool IsEnought(int amount)
    {
        Coins = PlayerPrefs.GetInt("Coins");
        return Coins >= amount;
    }
}
