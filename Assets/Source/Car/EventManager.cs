using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action OnGameOver;

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
