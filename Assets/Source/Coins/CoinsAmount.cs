using System;
using UnityEngine;
using PlayerPrefs = PlayerPrefsWrapper;

public class CoinsAmount : MonoBehaviour
{
    //public delegate void BankHendler(object sender, int OldCoinValue, int newCoinsValue);
    public delegate void BankHendler(int OldCoinValue, int newCoinsValue);
    public event BankHendler OnCoinValueChangedEvent;
    //public event Action<object, int, int> OnCoinValueChangedActionEvent;
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

    public void AddCoins( int amount)//object sender,
    {
        //Debug.Log(Coins);
        //Debug.Log(coins);
        //var oldCoinsValue = Coins;
        //coins += amount;
        //Debug.Log(coins + "+= "+ amount);
        //PlayerPrefs.SetInt("Coins", coins);

        //Debug.Log("Coins amount + " + coins);

        //OnCoinValueChangedEvent?.Invoke(sender, oldCoinsValue, Coins);
        //OnCoinValueChangedActionEvent?.Invoke(sender, oldCoinsValue, Coins);
        //OnCoinValueChangedEvent?.Invoke(oldCoinsValue, Coins);
        //OnCoinValueChangedActionEvent?.Invoke(oldCoinsValue, Coins);


        coins = PlayerPrefs.GetInt("Coins");
        var oldCoinsValue = Coins;
        coins += amount;
        Debug.Log("Coins amount + " + coins);
        PlayerPrefs.SetInt("Coins", coins);
        OnCoinValueChangedEvent?.Invoke(oldCoinsValue, Coins);
        OnCoinValueChangedActionEvent?.Invoke(oldCoinsValue, Coins);
    }

    public void SpendCoins( int amount) //object sender
    {
        var oldCoinsValue = Coins;
        coins -= amount;
        PlayerPrefs.SetInt("Coins", coins);

        //OnCoinValueChangedEvent?.Invoke(sender, oldCoinsValue, Coins);
        //OnCoinValueChangedActionEvent?.Invoke(sender, oldCoinsValue, Coins);                                                                                                                                    
        OnCoinValueChangedEvent?.Invoke(oldCoinsValue, Coins);
        OnCoinValueChangedActionEvent?.Invoke(oldCoinsValue, Coins);
    }

    public bool IsEnought(int amount)
    {
        Coins = PlayerPrefs.GetInt("Coins");
        return Coins >= amount;
    }
}
