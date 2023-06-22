using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public DeathCounterForInterstitialAd deathCounter;
    public static event Action OnGameOver;

    private void Start()
    {
        deathCounter.GetComponent<DeathCounterForInterstitialAd>();
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public void ZeroDeathCounter()
    {
        deathCounter.Dead();
    }
}
