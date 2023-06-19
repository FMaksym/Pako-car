using System.Collections;
using UnityEngine;
using Zenject;
using PlayerPrefs = PlayerPrefsWrapper;

public class CarDeath : MonoBehaviour
{
    [SerializeField] private CarController carController;
    [SerializeField] private GameObject _explosionParticle;

    private CoinsAmount _coins;
    private EarningCoins _earningCoins;
    private GameUIManager _gameUIManager;

    public bool IsLose { get; private set; }

    private void OnEnable()
    {
        EventManager.OnGameOver += Death;
    }

    private void OnDisable()
    {
        EventManager.OnGameOver -= Death;
    }

    [Inject]
    public void Construct(CoinsAmount coinsAmount, GameUIManager gameUiManager, EarningCoins earningCoins)
    {
        this._coins = coinsAmount;
        this._gameUIManager = gameUiManager;
        this._earningCoins = earningCoins;
    }

    private void Death()
    {
        IsLose = true;
        carController._moveSpeed = 0;
        _explosionParticle.SetActive(true);
        StartCoroutine(Wait(4));
        Debug.Log(PlayerPrefs.GetInt("Coins").ToString());
        StartCoroutine(WaitAndSetCoinsWalue(1));
        
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0;
    }
    IEnumerator WaitAndSetCoinsWalue(float time)
    {
        yield return new WaitForSeconds(time);
        _gameUIManager.GameOver(PlayerPrefs.GetInt("Coins").ToString());
    }
}
 